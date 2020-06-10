using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : ScriptableObject , IManager
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
        managers.Add(scene1Text = CreateInstance(typeof(Scene1Text)) as Scene1Text);
        managers.Add(bgManager = GameObject.FindObjectOfType<BackgroundManager>());
        managers.Add(textManager = GameObject.FindObjectOfType<TextManager>());
        wardrobeManager = CreateInstance(typeof(WardrobeManager)) as WardrobeManager;
        loadManager = FindObjectOfType<LoadManager>();
        foreach (var i in managers)
        {
            i.Initialize();
        }
        
        BackgroundManager.curBackground = BackgroundManager.backgroundsList[0];
        bgManager.ChangeBackground();
        SceneManager.sceneLoaded+=OnLevelLoaded;

        int ready=0;
        while (ready < managers.Count)
        {
            foreach(var i in managers)
            {
                if (i.status == ManagerStatus.Online)
                    ready++;
            }
        }
        status = ManagerStatus.Online;

    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
            wardrobeManager.Initialize();
        else
        {

            textManager = GameObject.FindObjectOfType<TextManager>();
            textManager.Initialize();
            textManager.OnLevelLoad();
        }
            
    }

    
    
}
