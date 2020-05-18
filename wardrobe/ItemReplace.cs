using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemReplace : MonoBehaviour, IPointerDownHandler
{
    public WardrobeItemTypeEnum type;
    public int id;

    ItemReplace(int id)
    {
        this.id = id;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (type)
        {
            case WardrobeItemTypeEnum.Haircut:
                {
                    MainManager.wardrobeManager.haircut.sprite = this.gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite;
                    //WardrobeManager.haircutSprite = this.gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite;
                    WardrobeDataManager.curHaircutID = this.id;
                    break;
                }
            case WardrobeItemTypeEnum.Outfit:
                {
                    MainManager.wardrobeManager.outfit.sprite = this.gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite;
                    //WardrobeManager.outfitSprite = this.gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite;
                    WardrobeDataManager.curOutfitID = this.id;
                    break;
                }
            case WardrobeItemTypeEnum.Item:
                {

                    break;
                }
            default:
                {
                    Debug.Log("Error");
                    break;
                }
        }
       
    }
}
