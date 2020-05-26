using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour, IManager
{
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    VideoPlayer bgVideoPlayer;
    bool isQHD;
    public RawImage targetTexture;

    public List<string> backgroundsList;
    public void Initialize()
    {
        ListInitialize();
        bgVideoPlayer = GetComponent<VideoPlayer>();
        targetTexture = GameObject.FindGameObjectWithTag("Background").GetComponent<RawImage>();
        if (Screen.height<2000 && Screen.width < 2000)
        {
            isQHD = false;
            MainManager.biggerText = false;
        }
        else
        {
            isQHD = true;         
            MainManager.biggerText = true;
        }
        StartCoroutine(PlayVideo());
        status = ManagerStatus.Online;
    }

    public void ChangeBackground(string path)
    {
        if (isQHD)
            bgVideoPlayer.clip = Resources.Load<VideoClip>("Videos/Background/" + path + "2K");
        else
            bgVideoPlayer.clip = Resources.Load<VideoClip>("Videos/Background/" + path + "FULLHD");

        
    }


    IEnumerator PlayVideo()
    {
        bgVideoPlayer.Prepare();
        while (!bgVideoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(1);
            break;
        }
        targetTexture.texture = bgVideoPlayer.texture;
        bgVideoPlayer.Play();
    }

    public void ListInitialize()
    {
        backgroundsList = new List<string>()
        {
            "dream",
            "Wardrobe",
            "prologue"
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
