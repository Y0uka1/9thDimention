using UnityEngine;

public class WardrobeButton : MonoBehaviour
{
    UnityEngine.UI.Button button;
    void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (MainManager.loadManager.isLoading == false)
        {
            button.interactable = false;
            MainManager.loadManager.LoadLevelById(2);
        }
    }

    
}
