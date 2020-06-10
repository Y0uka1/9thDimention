using UnityEngine;


public class WardrobeAccept : MonoBehaviour
{
    UnityEngine.UI.Button button;
    public delegate void ScreenTapped();
    public static event ScreenTapped OnScreenTapped;
    void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        MainManager.wardrobeManager.itemSwitched += Unblock;
        button.interactable = false;
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        WardrobeDataManager.DataSave();
        button.interactable = false;
    }

    void Unblock()
    {
        button.interactable = true;
    }
}
