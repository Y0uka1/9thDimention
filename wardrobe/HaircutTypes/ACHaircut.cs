using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class ACHaircut : MonoBehaviour, IPointerDownHandler
{
    public Image typeImage;
    public List<WardrobeIDDictionary.SpriteDictionary> colors;

    public void OnPointerDown(PointerEventData eventData)
    {
        MainManager.wardrobeManager.ConcreteChangeList(colors, WardrobeItemTypeEnum.Haircut);
    }
}
