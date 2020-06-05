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

    public bool isTyping=true;
    public bool skipTyping = false;
    public Coroutine printCouroutine;

    Vector3 centerPos;
    Vector3 rightPos;
    Vector3 leftPos;
   
    public void Initialize()
    {

       // this.hideFlags = HideFlags.DontSave;
        centerPos = GameObject.FindGameObjectWithTag("center").GetComponent<RectTransform>().position;
        rightPos = GameObject.FindGameObjectWithTag("right").GetComponent<RectTransform>().position;
        leftPos = GameObject.FindGameObjectWithTag("left").GetComponent<RectTransform>().position;
        characterImg = GameObject.Find("Character").GetComponent<Image>();
        characterImg.enabled = false;
        textPanel = GetComponentInChildren<Image>();
        charName = textPanel.transform.GetChild(1).GetComponent<Text>();
        replicaText = textPanel.transform.GetChild(0).GetComponent<Text>();
        charName.rectTransform.anchorMin = new Vector2(0, 1);
        charName.rectTransform.anchorMax = new Vector2(1, 1);
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
        isTyping = false;
    }


    public IEnumerator ShowText(Name_ReplicaStruct text)
    {
        //isTyping = true;

        

        //RectTransform replicaBg = textPanel.transform.parent.gameObject.GetComponent<RectTransform>();

        if (lastState != text.state || text.state == TextState.Special)
        {
            isTyping = true;
            StartCoroutine(Tools.MakeTransparent(characterImg, 0.5f, true));
             StartCoroutine(Tools.MakeTransparent(textPanel, 0.5f,true));
            yield return StartCoroutine(Tools.MakeTransparentText(replicaText, 0.5f, true));
            if (text.name != CharactersName.StorryTeller)
            {

                string name = Enum.GetName(typeof(CharactersName), text.name);
                if (name.Contains("Unknown_"))
                    name = name.Substring(8);
                characterImg.sprite = Resources.Load<Sprite>($"sprites/{name}/{name}_{Enum.GetName(typeof(CharacterEmotions), text.emotion)}");
                //characterImg.enabled = false;
            }
            
                

             float replica_size;
            float nameSize;
            string path;
             if(text.replica.Length>58 && text.replica.Length < 140)
             {
                replica_size = 335;
                nameSize = 100;
                path = "medium";
             }else if(text.replica.Length>140)
            {
                replica_size = 435;
                nameSize = 85;
                path = "big";
            }
            else
            {
                replica_size = 235;
                nameSize = 75;
                path = "little";
            }

             Vector2 namePos = new Vector2(-175, nameSize);
            Vector2 namePosMin;
            Vector2 namePosMax;
            namePosMin = new Vector2(10, -nameSize);   //
            namePosMax = new Vector2(-400, nameSize/3);
            switch (text.state)
            {
                case TextState.Center:
                    {
                        characterImg.enabled = false;
                        if (path == "little")
                            path = "medium";
                        textPanel.sprite = Resources.Load<Sprite>($"gui/{path}Center");
                        textPanel.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                        textPanel.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                        textPanel.rectTransform.anchoredPosition = Vector2.zero;
                        replicaText.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                        replicaText.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                        textPanel.rectTransform.sizeDelta = new Vector2(725, replica_size);
                        replicaText.rectTransform.sizeDelta = new Vector2(625, replica_size-80);
                        replicaText.rectTransform.anchoredPosition = Vector3.zero;
                        break;
                    }

                case TextState.Left:
                    {
                        textPanel.sprite = Resources.Load<Sprite>($"gui/{path}Left");
                       // textPanel.rectTransform.position = leftPos;
                        charName.rectTransform.anchoredPosition = namePos;
                        charName.rectTransform.offsetMin = namePosMin;
                        charName.rectTransform.offsetMax = namePosMax;
                        textPanel.rectTransform.sizeDelta = new Vector2(650, replica_size-30);
                        textPanel.rectTransform.anchorMin = new Vector2(0, 0);
                        textPanel.rectTransform.anchorMax = new Vector2(1, 0);
                        textPanel.rectTransform.anchoredPosition = new Vector2(-120, 200);
                       // replicaText.rectTransform.sizeDelta = new Vector2(650, replica_size-30);
                        replicaText.rectTransform.anchorMin = new Vector2(0, 0);
                        replicaText.rectTransform.anchorMax = new Vector2(1, 0);
                        replicaText.rectTransform.offsetMin = new Vector2(15, -replica_size);
                        replicaText.rectTransform.offsetMax = new Vector2(-15, (replica_size-55));
                        textPanel.rectTransform.offsetMin = new Vector2(0, 0);
                        textPanel.rectTransform.offsetMax = new Vector2(-340, replica_size-30);
                        textPanel.rectTransform.anchoredPosition = new Vector2(textPanel.rectTransform.anchoredPosition.x, 200);
                        replicaText.rectTransform.anchoredPosition = new Vector3(10,-80,0);
                        characterImg.rectTransform.anchoredPosition = new Vector2(-50, 0);
                        characterImg.enabled = true;
                        break;
                    }
                case TextState.Right:
                    {
                        textPanel.sprite = Resources.Load<Sprite>($"gui/{path}Right");
                       // textPanel.rectTransform.position = rightPos;
                        charName.rectTransform.anchoredPosition = new Vector3(-namePos.x, namePos.y);
                        charName.rectTransform.offsetMin = new Vector2(-namePosMin.x, namePosMin.y);
                        charName.rectTransform.offsetMax = new Vector2(-namePosMax.x, namePosMax.y);
                        textPanel.rectTransform.anchorMin = new Vector2(0, 0);
                        textPanel.rectTransform.anchorMax = new Vector2(1, 0);
                        textPanel.rectTransform.sizeDelta = new Vector2(650, replica_size-30);
                        textPanel.rectTransform.anchoredPosition = new Vector2(120, 200);
                       // replicaText.rectTransform.sizeDelta = new Vector2(650, replica_size-30);
                        textPanel.rectTransform.offsetMin = new Vector2(340, 0);
                        textPanel.rectTransform.offsetMax = new Vector2(0, replica_size );
                        replicaText.rectTransform.anchorMin = new Vector2(0, 0);
                        replicaText.rectTransform.anchorMax = new Vector2(1, 0);
                        replicaText.rectTransform.offsetMin = new Vector2(15, -replica_size);
                        replicaText.rectTransform.offsetMax = new Vector2(-15, (replica_size-55));
                        textPanel.rectTransform.anchoredPosition = new Vector2(textPanel.rectTransform.anchoredPosition.x, 200);
                        replicaText.rectTransform.anchoredPosition = new Vector3(10, -80, 0);
                        characterImg.rectTransform.anchoredPosition = new Vector2(150, 0);
                        characterImg.enabled = true;
                        break;
                    }
                case TextState.Special:
                    {
                        characterImg.enabled = false;
                        text.ScriptEvent();
                         break;
                    }
               
            }
            if (text.state != TextState.Special && text.state != TextState.NULL)
            {
                StartCoroutine(Tools.MakeTransparent(textPanel, 0.5f, false));
                StartCoroutine(Tools.MakeTransparentText(replicaText, 0.5f, false));
            }
        }
        lastState = text.state;
        if (text.state != TextState.Special)
        {
            charName.text = text.NameToString(text.name);
            StartCoroutine(Tools.MakeTransparent(characterImg, 0.5f, false));
            yield return printCouroutine = StartCoroutine(Tools.printByLetter(text.replica, replicaText));
           
            isTyping = false;
        }
        //replicaText.text = "";
        //isTyping = false;
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
