using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour, IManager
{

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


   
    public void Initialize()
    {
        characterImg = GameObject.Find("Character").GetComponent<Image>();
        characterImg.enabled = false;
        textPanel = GameObject.Find("ReplicaBGCenter").GetComponent<Image>();
        charName = textPanel.transform.GetChild(1).GetComponent<Text>();
        replicaText = textPanel.transform.GetChild(0).GetComponent<Text>();

        
        //charName.rectTransform.anchorMin = new Vector2(0, 1);
        //charName.rectTransform.anchorMax = new Vector2(1, 1);

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
        
        if (lastState != text.state || text.state == TextState.Special)
        {
            isTyping = true;
            StartCoroutine(Tools.MakeTransparent(characterImg, 0.5f, true));
            StartCoroutine(Tools.MakeTransparent(textPanel, 0.5f, true));
            StartCoroutine(Tools.MakeTransparentText(charName, 0.5f, true));
            yield return StartCoroutine(Tools.MakeTransparentText(replicaText, 0.5f, true));
            if (text.name != CharactersName.StorryTeller)
            {

                string name = Enum.GetName(typeof(CharactersName), text.name);
                if (name.Contains("Unknown_"))
                    name = name.Substring(8);
                characterImg.sprite = Resources.Load<Sprite>($"sprites/{name}/{name}_{Enum.GetName(typeof(CharacterEmotions), text.emotion)}");
            }

            string path;
            if (text.replica.Length >140)
            {
                path = "";
            }
            else if (text.replica.Length <= 140 && text.replica.Length > 53)
            {
                path = "Medium";
            }
            else
            {
                path = "Small";
            }

            switch (text.state)
            {
                case TextState.Center:
                    {
                        characterImg.enabled = false;
                        textPanel = GameObject.Find("ReplicaBGCenter"+path).GetComponent<Image>();
                        charName = textPanel.transform.GetChild(1).GetComponent<Text>();
                        replicaText = textPanel.transform.GetChild(0).GetComponent<Text>();
                        
                        break;
                    }

                case TextState.Left:
                    {
                        textPanel = GameObject.Find("ReplicaBGLeft" + path).GetComponent<Image>();
                        charName = textPanel.transform.GetChild(1).GetComponent<Text>();
                        replicaText = textPanel.transform.GetChild(0).GetComponent<Text>();
                        charName.text = text.NameToString(text.name);
                        characterImg.rectTransform.anchoredPosition = new Vector2(-65, 150);
                        characterImg.enabled = true;
                        StartCoroutine(FlyCamera(2));
                        break;
                    }
                case TextState.Right:
                    {
                        textPanel = GameObject.Find("ReplicaBGRight" + path).GetComponent<Image>();
                        charName = textPanel.transform.GetChild(1).GetComponent<Text>();
                        replicaText = textPanel.transform.GetChild(0).GetComponent<Text>();
                        charName.text = text.NameToString(text.name);
                        characterImg.rectTransform.anchoredPosition = new Vector2(300, 150);
                        characterImg.enabled = true;
                        StartCoroutine(FlyCamera(1));
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
                StartCoroutine(Tools.MakeTransparentText(charName, 0.5f, false));
            }

        }
        lastState = text.state;
        if (text.state != TextState.Special)
        {
            charName.text = text.NameToString(text.name);
            StartCoroutine(Tools.MakeTransparent(characterImg, 0.5f, false));
            replicaText.text = text.replica;
            isTyping = false;
        }
    }
    public void OnTextChanged()
    {
       StartCoroutine(ShowText(MainManager.scene1Text.GetReplica()));
    }

    private void OnDestroy()
    {
        TapSpace.OnScreenTappedEvent -=OnTextChanged;
    }

    IEnumerator FlyCamera(int state)
    {
        RectTransform rect;
        rect = MainManager.bgManager.targetTexture.GetComponent<RectTransform>();
        

        if (state == 1)
        {
            float newPos = rect.offsetMin.x - 75; 
            while (rect.offsetMin.x > newPos)
            {
                rect.offsetMax = new Vector2(rect.offsetMax.x - (1000 * Time.deltaTime), rect.offsetMax.y);
                rect.offsetMin = new Vector2(rect.offsetMin.x - (1000 * Time.deltaTime), rect.offsetMin.y);
                yield return null;
            }      
        }else if (state == 2)
        {
            float newPos = rect.offsetMin.x + 75;
            while (rect.offsetMin.x < newPos)
            {
                rect.offsetMax = new Vector2(rect.offsetMax.x + (1000 * Time.deltaTime), rect.offsetMax.y);
                rect.offsetMin = new Vector2(rect.offsetMin.x + (1000 * Time.deltaTime), rect.offsetMin.y);
                yield return null;
            }
        }
    }
}
