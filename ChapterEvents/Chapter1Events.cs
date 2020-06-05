using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Events : MonoBehaviour
{
    GameObject wardrobe;
    GameObject wardrobeButton;
    public static bool cmaeraFlyDone = false;

    public void Caw()
    {
        StartCoroutine(PlayCaw());
    }

    IEnumerator PlayCaw()
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/caw");
        AudioSource.PlayClipAtPoint(clip, transform.position);

        yield return new WaitForSeconds(clip.length + 1f);
        TapSpace.Next();
    }

    public void Tutorial1()
    {
       MainManager.textManager.isTyping = true;
        StartCoroutine(Tutorial1(MainManager.textManager.replicaText.text));
    }

    public void LoadDream()
    {
        MainManager.textManager.isTyping = true;
        
        StartCoroutine(MainManager.loadManager.Fade(LoadDreamC()));
       
    }

    IEnumerator LoadDreamC()
    {
        //StartCoroutine(MainManager.loadManager.Fade());
        //yield return new WaitForSeconds(1.25f);
       
        BackgroundManager.curBackground = BackgroundManager.backgroundsList[2];
        MainManager.bgManager.ChangeBackground();
        MainManager.bgManager.targetTexture.GetComponent<RectTransform>().offsetMin = new Vector2(-1900, 0);
        MainManager.bgManager.targetTexture.GetComponent<RectTransform>().offsetMax = new Vector2(350, 0);

        while (!MainManager.bgManager.bgVideoPlayer.isPlaying)
            yield return new WaitForFixedUpdate();
        TapSpace.Next();
    }

    public void FlyingCamera()
    {
        MainManager.textManager.isTyping = true;
        StartCoroutine(FlyCamera());
    }

    IEnumerator FlyCamera()
    {
        RectTransform rect;
        rect = MainManager.bgManager.targetTexture.GetComponent<RectTransform>();

        yield return new WaitForSeconds(0.5f);
       
        while (rect.offsetMin.x<-300 && rect.offsetMax.x<1950)
        {
            rect.offsetMax = new Vector2(rect.offsetMax.x + 5, rect.offsetMax.y);
            rect.offsetMin = new Vector2(rect.offsetMin.x + 5, rect.offsetMin.y);
            yield return null;
        }

        Chapter1Events.cmaeraFlyDone = true;
        TapSpace.Next();
        MainManager.textManager.isTyping = false;
    }

    public void Tutorial2()
    {
        MainManager.textManager.isTyping = true;
        StartCoroutine(Tutorial2(MainManager.textManager.replicaText.text));
    }

    public void Initialize()
    {
        DontDestroyOnLoad(this.gameObject);
        wardrobe = Instantiate(Resources.Load<GameObject>("Prefabs/LidlWardrobe"));
        wardrobe.transform.SetParent(GameObject.Find("Canvas").transform);
       
        wardrobe.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        wardrobe.GetComponent<RectTransform>().localScale = Vector3.one;
        wardrobe.SetActive(false);

        wardrobeButton = GameObject.Find("WardrobeButton");
        wardrobeButton.SetActive(false);
    }

    IEnumerator Tutorial1(string text)
    {
        MainManager.textManager.textPanel.enabled = false;
        MainManager.textManager.replicaText.enabled = false;
        MainManager.textManager.textPanel.color = new Color(255, 255, 255, 0);
      
       // GameObject temp = new GameObject();
       
       // UnityEngine.UI.Image tempS = temp.AddComponent<UnityEngine.UI.Image>();
      GameObject temp =  Instantiate(Resources.Load<GameObject>("Prefabs/tut1"));
        UnityEngine.UI.Image tempS = temp.GetComponent<UnityEngine.UI.Image>();
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        //   tempS.rectTransform.anchorMin = new Vector2(0.02f, 0.5f);
        //   tempS.rectTransform.anchorMax = new Vector2(0.98f, 0.5f);

          tempS.rectTransform.offsetMin = new Vector2(25,0);
          tempS.rectTransform.offsetMax = new Vector2(-25, 400);

          tempS.rectTransform.anchoredPosition = new Vector2(0, 0);
        tempS.rectTransform.localScale = Vector2.one;    

        tempS.color = new Color(255, 255, 255, 0.01f);
        float alpha = tempS.color.a;
        Color color = tempS.color;

        for (float i = 0.0f; i < 1.0f; i += Time.deltaTime / 0.5f)
        {
            tempS.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, 1, i));
            yield return null;
        }
        bool check = false;
        bool makeTrans = false;
        TapSpace.OnScreenTapped destroy = new TapSpace.OnScreenTapped(() => {

            makeTrans = true;
            MainManager.textManager.isTyping = true;
        });
        TapSpace.OnScreenTappedEvent += destroy;

        MainManager.textManager.isTyping = false;

        while (!makeTrans)
            yield return null;
            
        alpha = tempS.color.a;
        color = tempS.color;

        for (float i = 0.0f; i < 1.0f; i += Time.deltaTime / 0.5f)
        {
            tempS.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, 0, i));
            yield return null;
        }
        check = true;

        while (!check)
            yield return null;
        Destroy(temp);
       // TapSpace.OnScreenTappedEvent -= destroy;
        MainManager.textManager.textPanel.enabled = true;
        MainManager.textManager.replicaText.enabled = true;
        MainManager.textManager.replicaText.text = "";
        MainManager.textManager.isTyping = false;
    }


    IEnumerator Tutorial2(string text)
    {
        MainManager.textManager.textPanel.enabled = false;
        MainManager.textManager.replicaText.enabled = false;
        MainManager.textManager.textPanel.color = new Color(255, 255, 255, 0);

       // GameObject temp = new GameObject();
       // temp.transform.SetParent(GameObject.Find("Canvas").transform);
       // UnityEngine.UI.Image tempS = temp.AddComponent<UnityEngine.UI.Image>();
        GameObject temp = Instantiate(Resources.Load<GameObject>("Prefabs/tut2"));
        UnityEngine.UI.Image tempS = temp.GetComponent<UnityEngine.UI.Image>();
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        //  tempS.rectTransform.anchorMin = new Vector2(0.1f, 0.5f);
        //   tempS.rectTransform.anchorMax = new Vector2(0.9f, 0.5f);

        tempS.rectTransform.anchoredPosition = new Vector2(0,0);
        tempS.rectTransform.localScale = Vector2.one;
          tempS.rectTransform.offsetMin = new Vector2(25, 0);
          tempS.rectTransform.offsetMax = new Vector2(-25, 500);
         tempS.rectTransform.anchoredPosition = new Vector2(0, 0);

        tempS.color = new Color(255, 255, 255, 0.01f);
        float alpha = tempS.color.a;
        Color color = tempS.color;

        for (float i = 0.0f; i < 1.0f; i += Time.deltaTime / 0.5f)
        {
            tempS.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, 1, i));
            yield return null;
        }
        bool check = false;
        bool makeTrans = false;
        TapSpace.OnScreenTapped destroy = new TapSpace.OnScreenTapped(() => {

            makeTrans = true;
            MainManager.textManager.isTyping = true;
        });
        TapSpace.OnScreenTappedEvent += destroy;
        MainManager.textManager.isTyping = false;
        while (!makeTrans)
            yield return null;

        alpha = tempS.color.a;
        color = tempS.color;

        for (float i = 0.0f; i < 1.0f; i += Time.deltaTime / 0.5f)
        {
            tempS.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, 0, i));
            yield return null;
        }
        check = true;

        while (!check)
            yield return null;
        Destroy(temp);
        TapSpace.OnScreenTappedEvent -= destroy;
        MainManager.textManager.textPanel.enabled = true;
        MainManager.textManager.replicaText.enabled = true;
        MainManager.textManager.replicaText.text = "";
        wardrobeButton.SetActive(true);
        MainManager.textManager.isTyping = false;
    }


    public void LidlWardrobe()
    {
        MainManager.textManager.isTyping = true;
        TapSpace.image.raycastTarget = false;
        LidlWardrobeAccept.OnScreenTapped += WardrobeClose;
        wardrobe.SetActive(true);
        RectTransform wbRTransform = wardrobe.GetComponent<RectTransform>();
        wbRTransform.offsetMin = Vector2.zero;
        wbRTransform.offsetMax = Vector2.zero;
        MainManager.wardrobeManager.Initialize();     
    }

    private void WardrobeClose()
    {
        wardrobe.SetActive(false);
        TapSpace.Next();
        
        Destroy(wardrobe);
        TapSpace.image.raycastTarget = true;
        //MainManager.textManager.isTyping = false;
    }
}
