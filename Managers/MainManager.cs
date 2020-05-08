using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour , IManager
{
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;

    public static BackgroundManager bgManager;
    public static TextManager textManager;
    public static Scene1Text scene1Text;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        List<IManager> managers = new List<IManager>();
        managers.Add(bgManager = GameObject.FindObjectOfType<BackgroundManager>());
        managers.Add(textManager = GameObject.FindObjectOfType<TextManager>());
        scene1Text=GetComponent<Scene1Text>();
        scene1Text.Initialize();
        foreach (var i in managers)
        {
            i.Initialize();
        }

       
       
    }
}
