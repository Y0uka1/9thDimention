using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapSpace : MonoBehaviour, IPointerDownHandler
{
    public delegate void OnScreenTapped();
    public static event OnScreenTapped OnScreenTappedEvent;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (MainManager.textManager.gameObject != null)
        {
            Debug.Log("Tapped");
            if (!MainManager.textManager.isTyping)
            {
                MainManager.scene1Text.index++;
                OnScreenTappedEvent.Invoke();
            }
            
        }
        else
        {
            Debug.Log("NULL");
        }
    }
}
