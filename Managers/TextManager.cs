using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour, IManager
{
    delegate void ScriptEvent();
    ScriptEvent scriptEvent;

    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    string curText;
    public Image textPanel;
    public Text charName;
    public Text replicaText;

    public Image characterImg;

    TextState lastState;

    public bool isTyping=false;
    public bool skipTyping = false;
    public Coroutine printCouroutine;

    Vector3 centerPos;
    Vector3 rightPos;
    Vector3 leftPos;
    Vector3 namePos = new Vector3(-195, 200, 0);
    public void Initialize()
    {
       // this.hideFlags = HideFlags.DontSave;
        centerPos = GameObject.FindGameObjectWithTag("center").GetComponent<RectTransform>().position;
        rightPos = GameObject.FindGameObjectWithTag("right").GetComponent<RectTransform>().position;
        leftPos = GameObject.FindGameObjectWithTag("left").GetComponent<RectTransform>().position;
        characterImg = GameObject.Find("Character").GetComponent<Image>(); ;
        textPanel = GetComponentInChildren<Image>();
        charName = textPanel.transform.GetChild(1).GetComponent<Text>();
        replicaText = textPanel.transform.GetChild(0).GetComponent<Text>();
        /*if (MainManager.biggerText == true)
        {
            replicaText.fontSize = 30;
            charName.fontSize = 30;
        }
        else
        {
            replicaText.fontSize = 25;
            charName.fontSize = 25;
        }*/
        TapSpace.OnScreenTappedEvent += OnTextChanged;
        lastState = TextState.NULL;
        status = ManagerStatus.Online;
        

    }

    public void OnLevelLoad()
    {
        Name_ReplicaStruct temp = MainManager.scene1Text.GetReplica();
        StartCoroutine(ShowText(temp));
    }


    public IEnumerator ShowText(Name_ReplicaStruct text)
    {
        replicaText.text = "";
        if (text.name != CharactersName.StorryTeller)
        {
            string name = Enum.GetName(typeof(CharactersName), text.name);
            if (name.Contains("Unknown_"))
                name = name.Substring(8);
            characterImg.sprite = Resources.Load<Sprite>($"sprites/{name}/{name}_{Enum.GetName(typeof(CharacterEmotions), text.emotion)}");
            Debug.Log($"sprites/{Enum.GetName(typeof(CharactersName), text.name)}/{Enum.GetName(typeof(CharactersName), text.name)}_{Enum.GetName(typeof(CharacterEmotions), text.emotion)}");
        }
        if (lastState != text.state)
        {
           yield return StartCoroutine(Tools.MakeTransparent(textPanel, 0.5f,true));
            
            switch (text.state)
            {
                case TextState.Center:
                    {
                        textPanel.sprite = Resources.Load<Sprite>("gui/text-center");
                        textPanel.rectTransform.position = centerPos;
                        replicaText.rectTransform.sizeDelta = new Vector2(625, 435);
                        replicaText.rectTransform.anchoredPosition = Vector3.zero;
                        break;
                    }

                case TextState.Left:
                    {
                        textPanel.sprite = Resources.Load<Sprite>("gui/text-left");
                        textPanel.rectTransform.position = leftPos;
                        charName.rectTransform.anchoredPosition = namePos;
                        replicaText.rectTransform.sizeDelta = new Vector2(625, 305);
                        replicaText.rectTransform.anchoredPosition = new Vector3(-2,-40,0);
                        break;
                    }
                case TextState.Right:
                    {
                        textPanel.sprite = Resources.Load<Sprite>("gui/text-right");
                        textPanel.rectTransform.position = rightPos;
                        charName.rectTransform.anchoredPosition = new Vector3(-namePos.x, namePos.y, namePos.z);
                        replicaText.rectTransform.sizeDelta = new Vector2(625, 305);
                        replicaText.rectTransform.anchoredPosition = new Vector3(-2, -40, 0);
                        break;
                    }
                case TextState.Special:
                    {
                        text.ScriptEvent();
                        yield break;
                    }
               
            }
            if (text.state != TextState.Special && text.state != TextState.NULL)
                StartCoroutine(Tools.MakeTransparent(textPanel, 0.5f, false));
        }

            charName.text = text.NameToString(text.name);
            printCouroutine = StartCoroutine(Tools.printByLetter(text.replica, replicaText));
        
    }

    public void OnTextChanged()
    {
       StartCoroutine(ShowText(MainManager.scene1Text.GetReplica()));
    }

    private void OnDestroy()
    {
        TapSpace.OnScreenTappedEvent -=OnTextChanged;
    }
}
