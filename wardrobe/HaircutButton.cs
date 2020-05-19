﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HaircutButton : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnPointerDown);
    }



    public void OnPointerDown()
    {
        MainManager.wardrobeManager.ChangeList(WardrobeItemTypeEnum.Haircut);
    }

}
