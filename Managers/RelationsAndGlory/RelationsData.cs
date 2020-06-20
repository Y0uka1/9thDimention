using UnityEngine;
using System.IO;

public class RelationsData 
{
    [SerializeField] int a;
    [SerializeField] int b;
    [SerializeField] int c;


    public static void SaveData(bool empty)
    {
        RelationsData temp = new RelationsData();
        if (empty)
        {
           temp = new RelationsData();
            temp.a = 0;
            temp.b = 0;
            temp.c = 0;
        }
        else
        {
            temp = MainManager.relationsData;
        }

        string json = JsonUtility.ToJson(temp);
        File.WriteAllText(Application.persistentDataPath + "relations.txt",json);
    }

    public static void LoadData()
    {
        RelationsData temp = new RelationsData();
        string json;
        try
        {
            json = File.ReadAllText(Application.persistentDataPath + "relations.txt");
        }
        catch
        {
            SaveData(true);
        }
        finally
        {
            json = File.ReadAllText(Application.persistentDataPath + "relations.txt");
        }
        JsonUtility.FromJsonOverwrite(json, temp);
        MainManager.relationsData = temp;
    }

}
