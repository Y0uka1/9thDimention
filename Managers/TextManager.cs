using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour, IManager
{
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    string curText;
    Image textPanel;
    Text charName;
    public Text replicaText;

    TextState lastState;

    public bool isTyping=false;
    public Coroutine printCouroutine;

    Vector3 centerPos = Vector3.zero;
    Vector3 rightPos = new Vector3(160, -715, 0);
    Vector3 leftPos = new Vector3(-160, -715, 0);
    Vector3 namePos = new Vector3(-195, 200, 0);
    public void Initialize()
    {
        textPanel = GetComponentInChildren<Image>();
        charName = textPanel.transform.GetChild(1).GetComponent<Text>();
        replicaText = textPanel.transform.GetChild(0).GetComponent<Text>();      
        TapSpace.OnScreenTappedEvent += OnTextChanged;
        lastState = TextState.NULL;
        Name_ReplicaStruct temp = MainManager.scene1Text.GetReplica();       
        StartCoroutine(ShowText(temp));
      
    }

    public IEnumerator ShowText(Name_ReplicaStruct text)
    {
        if (lastState != text.state)
        {
           yield return StartCoroutine(Tools.MakeTransparent(textPanel, 0.5f,true));

            switch (text.state)
            {
                case TextState.Center:
                    {
                        textPanel.sprite = Resources.Load<Sprite>("gui/text-center");
                        textPanel.rectTransform.anchoredPosition = centerPos;
                        replicaText.rectTransform.sizeDelta = new Vector2(665, 455);
                        replicaText.rectTransform.anchoredPosition=centerPos;
                        break;
                    }

                case TextState.Left:
                    {
                        textPanel.sprite = Resources.Load<Sprite>("gui/text-left");
                        textPanel.rectTransform.anchoredPosition = leftPos;
                        charName.rectTransform.anchoredPosition = namePos;
                        replicaText.rectTransform.sizeDelta = new Vector2(675, 325);
                        replicaText.rectTransform.anchoredPosition = new Vector3(-2,-40,0);
                        break;
                    }
                case TextState.Right:
                    {
                        textPanel.sprite = Resources.Load<Sprite>("gui/text-right");
                        textPanel.rectTransform.anchoredPosition = rightPos;
                        charName.rectTransform.anchoredPosition = new Vector3(-namePos.x, namePos.y, namePos.z);
                        replicaText.rectTransform.sizeDelta = new Vector2(675, 325);
                        replicaText.rectTransform.anchoredPosition = new Vector3(-2, -40, 0);
                        break;
                    }
            }

            StartCoroutine(Tools.MakeTransparent(textPanel, 0.5f, false));
        }
        

        //TODO Animations
        

        charName.text = text.NameToString(text.name);
        printCouroutine = StartCoroutine(Tools.printByLetter(text.replica, replicaText));
    }


    public void OnTextChanged()
    {
       StartCoroutine(ShowText(MainManager.scene1Text.GetReplica()));
    }
}
