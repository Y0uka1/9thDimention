using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WardrobeManager : MonoBehaviour
{
    public GameObject listContent;
    public  Image haircut;
    public  Image outfit;
    // [SerializeField] public static Sprite haircutSprite;
    // [SerializeField] public static Sprite outfitSprite;
    //public ManagerStatus status { get; set; } = ManagerStatus.Offline;

   

    public void Initialize()
    {
        listContent = GameObject.FindGameObjectWithTag("ListContent");
        haircut = GameObject.Find("CurrentHaircut").GetComponent<Image>();
        outfit = GameObject.Find("CurrentOutfit").GetComponent<Image>();

        SceneManager.sceneLoaded += OnSceneLoaded;
        Vector2 dynamicCellSize = new Vector2(Screen.width / 4, Screen.width / 4);
        GridLayoutGroup layout = listContent.GetComponent<GridLayoutGroup>();
        layout.cellSize = dynamicCellSize;
        layout.spacing = dynamicCellSize/4;

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
            MainManager.wardrobeManager.haircut.sprite = WardrobeIDDictionary.GetSpriteByID(WardrobeDataManager.curHaircutID);
            MainManager.wardrobeManager.outfit.sprite = WardrobeIDDictionary.GetSpriteByID(WardrobeDataManager.curOutfitID);
        }
    }

    public void ChangeList(int count)
    {
        foreach (Transform i in MainManager.wardrobeManager.listContent.transform)
        {
            GameObject.Destroy(i.gameObject);
        }
        MainManager.wardrobeManager.listContent.transform.DetachChildren();
        for (int i=0;i<count;i++)
        {
            GameObject temp = Instantiate(Resources.Load<GameObject>("Wardrobe/ItemBGPrefab"));
            temp.transform.parent = MainManager.wardrobeManager.listContent.transform;
        }
    }

    public void ConcreteChangeList(List<WardrobeIDDictionary.SpriteDictionary> colors, WardrobeItemTypeEnum type)
    {
        MainManager.wardrobeManager.ChangeList(colors.Count);
        int index = 0;
        foreach (Transform i in MainManager.wardrobeManager.listContent.transform)
        {
            i.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(colors[index].path);
            ItemReplace temp = i.gameObject.AddComponent<ItemReplace>();
            temp.type = type;
            temp.id = colors[index].id;
            index++;
        }
    }
}
