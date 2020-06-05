using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapSpace : MonoBehaviour, IPointerDownHandler
{
    public delegate void OnScreenTapped();
    public static event OnScreenTapped OnScreenTappedEvent;
    public static UnityEngine.UI.Image image;
    private void Start()
    {
       // DontDestroyOnLoad(this);
        image = GetComponent<UnityEngine.UI.Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (MainManager.textManager.gameObject != null && !MainManager.loadManager.isLoading)
        {
            

                if (!MainManager.textManager.isTyping)
                {
                    MainManager.textManager.isTyping = true;

                    MainManager.scene1Text.index++;
                    OnScreenTappedEvent.Invoke();
                 
                }
            
            
        }
    }

    public static void Next()
    {
        if (MainManager.textManager.gameObject != null)
        {

            
                MainManager.scene1Text.index++;
                OnScreenTappedEvent.Invoke();
           // MainManager.textManager.isTyping = false;

        }
    }
}
