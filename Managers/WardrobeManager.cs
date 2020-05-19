using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WardrobeManager : ScriptableObject
{
    public GameObject listContent;
    public  Image haircut;
    public  Image outfit;
     float quarter;
    // [SerializeField] public static Sprite haircutSprite;
    // [SerializeField] public static Sprite outfitSprite;
    //public ManagerStatus status { get; set; } = ManagerStatus.Offline;


    public void Initialize()
    {
        listContent = GameObject.FindGameObjectWithTag("ListContent");
        haircut = GameObject.Find("CurrentHaircut").GetComponent<Image>();
        outfit = GameObject.Find("CurrentOutfit").GetComponent<Image>();

        

        //float quarter = listContent.transform.parent.parent.GetComponent<RectTransform>().rect.width / 3;
         quarter = Screen.width / 4;
        SceneManager.sceneLoaded += OnSceneLoaded;

        //RectTransform view = listContent.transform.parent.parent.GetComponent<RectTransform>();
        //float temp = Screen.width/3;
        //view.sizeDelta = new Vector2(0,quarter+20);
        //Vector2 dynamicCellSize = new Vector2(quarter, quarter);
        HorizontalLayoutGroup layout = listContent.GetComponent<HorizontalLayoutGroup>();
        //layout.
        //layout.cellSize = dynamicCellSize;
        layout.spacing = quarter/4;

      /*  if (haircutSprite == null) {
            Debug.Log("H Empty");
            haircutSprite = Resources.Load<Sprite>("Wardrobe/Haircut/Hair_01_Brown");
        }   
            haircut.sprite = haircutSprite;

        if (outfitSprite == null) {
            Debug.Log("O Empty");
            outfitSprite = Resources.Load<Sprite>("Wardrobe/Outfit");
        }

        haircut.sprite = haircutSprite;
        outfit.sprite = outfitSprite;*/
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex==2)
        {
           haircut.sprite = WardrobeIDDictionary.GetSpriteByID(WardrobeDataManager.curHaircutID);
           outfit.sprite = WardrobeIDDictionary.GetSpriteByID(WardrobeDataManager.curOutfitID);
        }
    }

    public void ChangeList(int count)
    {
        foreach (Transform i in listContent.transform)
        {
            GameObject.Destroy(i.gameObject);
        }
        listContent.transform.DetachChildren();
        for (int i=0;i<count;i++)
        {
            GameObject temp = Instantiate(Resources.Load<GameObject>("Wardrobe/ItemBGPrefab"));
            temp.GetComponent<RectTransform>().sizeDelta = new Vector2(quarter, quarter);
            temp.transform.parent = listContent.transform;
        }
        
    }

    public void ConcreteChangeList(List<WardrobeIDDictionary.SpriteDictionary> colors, WardrobeItemTypeEnum type)
    {
        ChangeList(colors.Count);
        int index = 0;
        foreach (Transform i in listContent.transform)
        {
            i.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(colors[index].path);
            ItemReplace temp = i.gameObject.AddComponent<ItemReplace>();
            temp.type = type;
            temp.id = colors[index].id;
            index++;
        }
       
    }
}
