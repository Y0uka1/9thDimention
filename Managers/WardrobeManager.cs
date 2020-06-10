using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WardrobeManager : ScriptableObject
{
    public Text listContent;
    public  Image haircut;
    public  Image outfit;
    public int listIndex;
    public List<WardrobeIDDictionary.SpriteDictionary> list;
    WardrobeItemTypeEnum listType = WardrobeItemTypeEnum.Haircut;
    public event Action itemSwitched;


    public void Initialize()
    {
        TapSpace.image.raycastTarget = false;
        WardrobeDataManager.DataLoad();

        listContent = GameObject.FindGameObjectWithTag("ListContent").GetComponent<Text>();

        haircut = GameObject.Find("CurrentHaircut").GetComponent<Image>();
        outfit = GameObject.Find("CurrentOutfit").GetComponent<Image>();
        listIndex = 0;
        list = new List<WardrobeIDDictionary.SpriteDictionary>();
        
        LoadFromSave();
        listIndex = list.FindIndex(item => item.id == WardrobeDataManager.curHaircutID);
        listContent.text = WardrobeIDDictionary.haircutDictionary[listIndex].name;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void LoadFromSave()
    {
        list = WardrobeIDDictionary.haircutDictionary;
        listType = WardrobeItemTypeEnum.Haircut;
        haircut.sprite = WardrobeIDDictionary.GetSpriteByName(WardrobeDataManager.curHaircutID, WardrobeItemTypeEnum.Haircut);
        outfit.sprite = WardrobeIDDictionary.GetSpriteByName(WardrobeDataManager.curOutfitID,WardrobeItemTypeEnum.Outfit);
    }


    public void ChangeIten(bool next)
    {
        if (next)
            listIndex++;
        else
            listIndex--;

        if (listIndex < 0)
            listIndex = list.Count - 1;
        else if (listIndex >= list.Count)
            listIndex = 0;

        ItemChange();
    }

    private void ItemChange()
    {
        listContent.text = list[listIndex].name;
        if (listType == WardrobeItemTypeEnum.Haircut)
        {
            haircut.sprite = Resources.Load<Sprite>(list[listIndex].path);
            WardrobeDataManager.curHaircutID = list[listIndex].id;
        }
        else 
        {
            outfit.sprite = Resources.Load<Sprite>(list[listIndex].path);
            WardrobeDataManager.curOutfitID = list[listIndex].id;
        }
        itemSwitched.Invoke();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex==2)
        {
      
           haircut.sprite = WardrobeIDDictionary.GetSpriteByName(WardrobeDataManager.curHaircutID, WardrobeItemTypeEnum.Haircut);
           outfit.sprite = WardrobeIDDictionary.GetSpriteByName(WardrobeDataManager.curOutfitID,WardrobeItemTypeEnum.Outfit);
        }
    }

   public void ChangeList(WardrobeItemTypeEnum type)
    {
        listType = type;
        
        switch (type)
        {
            case WardrobeItemTypeEnum.Haircut:
                {
                    list = WardrobeIDDictionary.haircutDictionary;
                    listIndex = list.FindIndex(item => item.id == WardrobeDataManager.curHaircutID);
                    break;
                }
            case WardrobeItemTypeEnum.Outfit:
                {
                    list = WardrobeIDDictionary.outfitDictionary;
                    listIndex = list.FindIndex(item => item.id == WardrobeDataManager.curOutfitID);
                    break;
                }
            case WardrobeItemTypeEnum.Item:
                {
                    list = WardrobeIDDictionary.haircutDictionary;
                    break;
                }
        }
        ItemChange();
    }


}
