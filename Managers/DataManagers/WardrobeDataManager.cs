using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WardrobeDataManager : MonoBehaviour
{

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static string curHaircutID = "Светлые пепельные короткие волосы";
    public static string curOutfitID = "Повседневный наряд";
    static List<int> haircutList;
    public static List<int> outfitList;


    public static void DataSave()
    {

        WardeobeSaveStruct.SaveData();
    }

    public static void DataLoad()
    {
        WardeobeSaveStruct.LoadData();
    }

}
