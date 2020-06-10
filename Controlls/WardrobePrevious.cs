using UnityEngine;
public class WardrobePrevious : MonoBehaviour
{
    UnityEngine.UI.Button button;
    void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        MainManager.wardrobeManager.ChangeIten(false);
    }
}
