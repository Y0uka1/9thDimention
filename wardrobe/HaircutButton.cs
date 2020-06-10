﻿using UnityEngine;

public class HaircutButton : MonoBehaviour
{
    UnityEngine.UI.Button button;
    private void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnPointerDown);
    }



    public void OnPointerDown()
    {
        MainManager.wardrobeManager.ChangeList(WardrobeItemTypeEnum.Haircut);
    }

}
