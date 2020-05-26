using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Events : MonoBehaviour
{
    GameObject wardrobe;
    public void Tutorial1()
    {
        StartCoroutine(Tutorial1(MainManager.textManager.replicaText.text));
    }

    void Start()
    {
        wardrobe = GameObject.Find("LidlWardrobe");
        wardrobe.SetActive(false);
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
        tempS.rectTransform.anchorMin = new Vector2(0, 0.5f);
        tempS.rectTransform.anchorMax = new Vector2(1, 0.5f);
        tempS.rectTransform.offsetMin = new Vector2(0, MainManager.textManager.textPanel.rectTransform.offsetMin.y);
        tempS.rectTransform.offsetMax = new Vector2(0, MainManager.textManager.textPanel.rectTransform.offsetMax.y);
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

    public void LidlWardrobe()
    {
        
        wardrobe.SetActive(true);
        MainManager.textManager.isTyping = true;
    }

}
