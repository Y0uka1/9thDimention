using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class HaircutButton : MonoBehaviour, IPointerDownHandler
{
  

    

    public void OnPointerDown(PointerEventData eventData)
    {
        List<Type> types = new List<Type>(WardrobeItemType.GetItemList(WardrobeItemTypeEnum.Haircut));
        MainManager.wardrobeManager.ChangeList(types.Count);
        int index=0;
        foreach(Transform i in MainManager.wardrobeManager.listContent.transform)
        {
            i.gameObject.AddComponent(types[index]);
            index++;
        }
    }

}
