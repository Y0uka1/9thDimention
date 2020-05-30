using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeAccept : MonoBehaviour
{
    UnityEngine.UI.Button button;
    public delegate void ScreenTapped();
    public static event ScreenTapped OnScreenTapped;
     void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        WardrobeDataManager.DataSave();
        MainManager.textManager.isTyping = false;
        OnScreenTapped.Invoke();
       
    }

}
