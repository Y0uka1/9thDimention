using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WardrobeManager : ScriptableObject
{
    public Text listContent;
    public  Image haircut;
    public  Image outfit;
    float quarter;
    public int listIndex;
    public List<WardrobeIDDictionary.SpriteDictionary> list;
    WardrobeItemTypeEnum listType = WardrobeItemTypeEnum.Haircut;
    // [SerializeField] public static Sprite haircutSprite;
    // [SerializeField] public static Sprite outfitSprite;
    //public ManagerStatus status { get; set; } = ManagerStatus.Offline;


    public void Initialize()
    {
       // WardrobeDataManager.DataSave();
       WardrobeDataManager.DataLoad();

        listContent = GameObject.FindGameObjectWithTag("ListContent").GetComponent<Text>();

        haircut = GameObject.Find("CurrentHaircut").GetComponent<Image>();
        outfit = GameObject.Find("CurrentOutfit").GetComponent<Image>();
        listIndex = 0;
        list = new List<WardrobeIDDictionary.SpriteDictionary>();
        
        LoadFromSave();
        listIndex = list.FindIndex(item => item.name == WardrobeDataManager.curHaircutID);
        listContent.text = WardrobeDataManager.curHaircutID;
         //float quarter = listContent.transform.parent.parent.GetComponent<RectTransform>().rect.width / 3;
         //  quarter = Screen.width / 4;
        SceneManager.sceneLoaded += OnSceneLoaded;

       // RectTransform view = listContent.transform.parent.parent.GetComponent<RectTransform>();
       // float temp = Screen.height /5;
       // view.sizeDelta = new Vector2(0,temp);
       // view.anchoredPosition = new Vector2(0,temp/2);
        //Vector2 dynamicCellSize = new Vector2(quarter, quarter);
      //  HorizontalLayoutGroup layout = listContent.GetComponent<HorizontalLayoutGroup>();
        //layout.
        //layout.cellSize = dynamicCellSize;
       // layout.spacing = quarter/4;

      
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
            WardrobeDataManager.curHaircutID = list[listIndex].name;
        }
        else //(listType == WardrobeItemTypeEnum.Outfit)
        {
            outfit.sprite = Resources.Load<Sprite>(list[listIndex].path);
            WardrobeDataManager.curOutfitID = list[listIndex].name;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex==2)
        {
         //   Initialize();
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
                    listIndex = list.FindIndex(item => item.name == WardrobeDataManager.curHaircutID);
                    break;
                }
            case WardrobeItemTypeEnum.Outfit:
                {
                    list = WardrobeIDDictionary.outfitDictionary;
                    listIndex = list.FindIndex(item => item.name == WardrobeDataManager.curOutfitID);
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

   /* public void ConcreteChangeList(List<WardrobeIDDictionary.SpriteDictionary> colors, WardrobeItemTypeEnum type)
    {
        
        int index = 0;
        foreach (Transform i in listContent.transform)
        {
            i.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(colors[index].path);
            ItemReplace temp = i.gameObject.AddComponent<ItemReplace>();
            temp.type = type;
            temp.id = colors[index].id;
            index++;
        }
       
    }*/
}
