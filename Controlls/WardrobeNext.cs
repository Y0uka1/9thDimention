using UnityEngine;

public class WardrobeNext : MonoBehaviour
{
    UnityEngine.UI.Button button;
    void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        MainManager.wardrobeManager.ChangeIten(true);
    }
}
