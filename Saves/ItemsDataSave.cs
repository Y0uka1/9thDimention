using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDataSave
{
    [SerializeField] List<WardrobeIDDictionary.SpriteDictionary> itemsList;
    ItemsDataSave()
    {
        itemsList = new List<WardrobeIDDictionary.SpriteDictionary>(WardrobeIDDictionary.itemDictionary);
    }

    public static void SaveData()
    {
        string json = JsonUtility.ToJson(new ItemsDataSave());
        File.WriteAllText(Application.persistentDataPath + "Items.txt", json);
    }

    public static void LoadData()
    {
        string json = "";
        try
        {
            json = File.ReadAllText(Application.persistentDataPath + "Items.txt");
        }
        catch
        {
            SaveData();
        }
        ItemsDataSave temp = new ItemsDataSave();
        JsonUtility.FromJsonOverwrite(json, temp);
        WardrobeIDDictionary.itemDictionary = temp.itemsList;
       
    }
}

