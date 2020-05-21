using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WardrobeExitButton : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (MainManager.loadManager.isLoading == false)
        {
            button.interactable = false;
            MainManager.loadManager.LoadLevelById(1);
        }
    }

}
