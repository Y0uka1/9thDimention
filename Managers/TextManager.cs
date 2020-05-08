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
    Text replicaText;

    public bool isTyping=false;

    Vector3 centerPos = Vector3.zero;
    Vector3 rightPos = new Vector3(280, -360, 0);
    Vector3 leftPos = new Vector3(-180, -365, 0);
    Vector3 namePos = new Vector3(-120, 120, 0);
    public void Initialize()
    {
        textPanel = GetComponentInChildren<Image>();
        charName = textPanel.transform.GetChild(1).GetComponent<Text>();
        replicaText = textPanel.transform.GetChild(0).GetComponent<Text>();      
        TapSpace.OnScreenTappedEvent += OnTextChanged;
        
    }

    public void ShowText(Name_ReplicaStruct text)
    {

        //TODO Animations
        switch (text.state)
        {
            case TextState.Center:
                {
                    textPanel.sprite = Resources.Load<Sprite>("gui/text-center");
                    textPanel.rectTransform.anchoredPosition = centerPos;
                    break;
                }

            case TextState.Left:
                {
                    textPanel.sprite = Resources.Load<Sprite>("gui/text-left");
                    textPanel.rectTransform.anchoredPosition = leftPos;
                    charName.rectTransform.anchoredPosition = namePos;
                    break;
                }
            case TextState.Right:
                {
                    textPanel.sprite = Resources.Load<Sprite>("gui/text-right");
                    textPanel.rectTransform.anchoredPosition = rightPos;
                    charName.rectTransform.anchoredPosition = new Vector3(-namePos.x, namePos.y, namePos.z);
                    break;
                }
        }

        charName.text = text.NameToString(text.name);
        StartCoroutine(Tools.printByLetter(text.replica, replicaText));
    }


    public void OnTextChanged()
    {
        ShowText(MainManager.scene1Text.GetReplica());
    }
}
