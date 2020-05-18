using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WardrobeButton : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        MainManager.loadManager.LoadLevelById(2);
    }

    
}
