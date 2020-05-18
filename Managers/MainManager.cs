using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour , IManager
{
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;

    public static BackgroundManager bgManager;
    public static TextManager textManager;
    public static Scene1Text scene1Text;
    public static WardrobeManager wardrobeManager;
    public static bool biggerText;
    public static LoadManager loadManager;

    public void Initialize()
    {
        List<IManager> managers = new List<IManager>();
        managers.Add(scene1Text = GetComponent<Scene1Text>());
        managers.Add(bgManager = GameObject.FindObjectOfType<BackgroundManager>());
        managers.Add(textManager = GameObject.FindObjectOfType<TextManager>());
        wardrobeManager = GetComponent<WardrobeManager>();
        loadManager = FindObjectOfType<LoadManager>();
        //scene1Text.Initialize();
        foreach (var i in managers)
        {
            i.Initialize();
        }
        bgManager.ChangeBackground(bgManager.backgroundsList[0]);

        status = ManagerStatus.Online;
       // Debug.Log(Application.persistentDataPath);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 2)
            wardrobeManager.Initialize();
        else
        {
            bgManager = GameObject.FindObjectOfType<BackgroundManager>();
            bgManager.Initialize();
            textManager = GameObject.FindObjectOfType<TextManager>();
            textManager.Initialize();
            textManager.OnLevelLoad();
        }
            
    }

    
    
}
