using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Events : MonoBehaviour
{
    GameObject wardrobe;
    GameObject wardrobeButton;
    public void Tutorial1()
    {
        StartCoroutine(Tutorial1(MainManager.textManager.replicaText.text));
    }

    public void LoadDream()
    {
        StartCoroutine(MainManager.loadManager.Fade());
        StartCoroutine(LoadDreamC());
       
    }

    IEnumerator LoadDreamC()
    {
        yield return new WaitForSeconds(1.25f);
        MainManager.bgManager.ChangeBackground(BackgroundManager.backgroundsList[2]);
        MainManager.bgManager.targetTexture.GetComponent<RectTransform>().offsetMin = new Vector2(-1900, 0);
        MainManager.bgManager.targetTexture.GetComponent<RectTransform>().offsetMax = new Vector2(350, 0);
        TapSpace.Next();
    }

    public void FlyingCamera()
    {
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
       
    }

    public void Tutorial2()
    {
        StartCoroutine(Tutorial2(MainManager.textManager.replicaText.text));
    }

    public void Initialize()
    {
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
      
        GameObject temp = new GameObject();
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        UnityEngine.UI.Image tempS = temp.AddComponent<UnityEngine.UI.Image>();
        tempS.sprite = Resources.Load<Sprite>("Tutorial/tut1");
        tempS.rectTransform.anchorMin = new Vector2(0.02f, 0.5f);
        tempS.rectTransform.anchorMax = new Vector2(0.98f, 0.5f);
      
        tempS.rectTransform.offsetMin = new Vector2(0,0);
        tempS.rectTransform.offsetMax = new Vector2(0, 400);

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
        });
        TapSpace.OnScreenTappedEvent += destroy;

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
    }


    IEnumerator Tutorial2(string text)
    {
        MainManager.textManager.textPanel.enabled = false;
        MainManager.textManager.replicaText.enabled = false;
        MainManager.textManager.textPanel.color = new Color(255, 255, 255, 0);

        GameObject temp = new GameObject();
        temp.transform.SetParent(GameObject.Find("Canvas").transform);
        UnityEngine.UI.Image tempS = temp.AddComponent<UnityEngine.UI.Image>();
        tempS.sprite = Resources.Load<Sprite>("Tutorial/tut2");
        tempS.rectTransform.anchorMin = new Vector2(0.1f, 0.5f);
        tempS.rectTransform.anchorMax = new Vector2(0.9f, 0.5f);
        
        //tempS.rectTransform.position = new Vector2(0,0);
       
        tempS.rectTransform.offsetMin = new Vector2(100, 0);
        tempS.rectTransform.offsetMax = new Vector2(100, 600);
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
        });
        TapSpace.OnScreenTappedEvent += destroy;

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
    }


    public void LidlWardrobe()
    {
        WardrobeAccept.OnScreenTapped += WardrobeClose;
        wardrobe.SetActive(true);
        MainManager.wardrobeManager.Initialize();
        MainManager.textManager.isTyping = true;
    }

    private void WardrobeClose()
    {
        wardrobe.SetActive(false);
        TapSpace.Next();
        
        Destroy(wardrobe);       
    }
}
