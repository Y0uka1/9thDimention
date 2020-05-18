using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BackgroundManager : MonoBehaviour, IManager
{
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    VideoPlayer bgVideoPlayer;
    bool isQHD;

    public List<string> backgroundsList;
    public void Initialize()
    {
        ListInitialize();
        bgVideoPlayer = GetComponent<VideoPlayer>();
        if(Screen.height<2000 && Screen.width < 2000)
        {
            isQHD = false;
            MainManager.biggerText = false;
        }
        else
        {
            isQHD = true;         
            MainManager.biggerText = true;
        }

        status = ManagerStatus.Online;
    }

    public void ChangeBackground(string path)
    {
        if (isQHD)
            bgVideoPlayer.clip = Resources.Load<VideoClip>("Videos/Background/" + path + "2K");
        else
            bgVideoPlayer.clip = Resources.Load<VideoClip>("Videos/Background/" + path + "FULLHD");

        
    }


    public void ListInitialize()
    {
        backgroundsList = new List<string>()
        {
            "dream",
            "Wardrobe"
        };
    }


    public void OnStartAnimation()
    {
       // MoveTool.MoveToPosition(backgroundAnimated, new Vector3(5.11f, -0.003f, 1f), 0f);
    }

   /* public void OnLevelWasLoaded(int level)
    {
        if (bgVideoPlayer.clip != null)
            bgVideoPlayer.Play();
    }*/
}
