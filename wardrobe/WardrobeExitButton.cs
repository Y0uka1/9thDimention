using UnityEngine;



public class WardrobeExitButton : MonoBehaviour
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
            TapSpace.image.raycastTarget = true;
            MainManager.loadManager.LoadLevelById(1);
        }
    }

}
