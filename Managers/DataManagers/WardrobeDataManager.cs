using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WardrobeDataManager : MonoBehaviour
{

    private const string SAVE_SEPARATOR = "#SAVE-VALUE#";

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static int curHaircutID = 1;
    public static int curOutfitID = 99;
    static List<int> haircutList;
    public static List<int> outfitList;

    static string json;

   [SerializeField] int serializeCurHaircut;
    [SerializeField] int serializeCurOutfit;
    WardrobeDataManager()
    {
        serializeCurHaircut = curHaircutID;
        serializeCurOutfit = curOutfitID;
    }

    public static void DataSave()
    {
        json = JsonUtility.ToJson(new WardrobeDataManager());
        Debug.Log(json);
    }

    public static void DataLoad()
    {
        WardrobeDataManager temp = JsonUtility.FromJson<WardrobeDataManager>(json);
        curHaircutID = temp.serializeCurHaircut;
        curOutfitID = temp.serializeCurOutfit;
        
    }

}
