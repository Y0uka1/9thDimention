using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WardeobeSaveStruct
{
    //private const string SAVE_SEPARATOR = "#SAVE-VALUE#";

    [SerializeField] string serializeCurHaircut;
    [SerializeField] string serializeCurOutfit;


    WardeobeSaveStruct()
    {
        serializeCurHaircut = WardrobeDataManager.curHaircutID;
        serializeCurOutfit = WardrobeDataManager.curOutfitID;
    }

    public static void SaveData()
    { 
        string json = JsonUtility.ToJson(new WardeobeSaveStruct());
        File.WriteAllText(Application.dataPath + "curWardrobe.txt", json);
    }

    public static void LoadData()
    {
        string json = File.ReadAllText(Application.dataPath + "curWardrobe.txt");
        WardeobeSaveStruct temp = new WardeobeSaveStruct();
        JsonUtility.FromJsonOverwrite(json,temp);
        WardrobeDataManager.curHaircutID = temp.serializeCurHaircut;
        WardrobeDataManager.curOutfitID = temp.serializeCurOutfit;
    }
}
