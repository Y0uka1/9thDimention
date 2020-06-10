using UnityEngine;
using System.IO;

public class WardeobeSaveStruct
{

    [SerializeField] int serializeCurHaircut;
    [SerializeField] int serializeCurOutfit;


    WardeobeSaveStruct()
    {
        serializeCurHaircut = WardrobeDataManager.curHaircutID;
        serializeCurOutfit = WardrobeDataManager.curOutfitID;
    }

    public static void SaveData()
    { 
        string json = JsonUtility.ToJson(new WardeobeSaveStruct());
        File.WriteAllText(Application.persistentDataPath + "curWardrobe.txt", json);
    }

    public static void LoadData()
    {
        string json ="";
        try
        {
            json = File.ReadAllText(Application.persistentDataPath + "curWardrobe.txt");
        }
        catch
        {
            SaveData();
        }
        WardeobeSaveStruct temp = new WardeobeSaveStruct();
        JsonUtility.FromJsonOverwrite(json,temp);
        WardrobeDataManager.curHaircutID = temp.serializeCurHaircut;
        WardrobeDataManager.curOutfitID = temp.serializeCurOutfit;
    }
}
