using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BackgroundManager : MonoBehaviour, IManager
{
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    VideoPlayer bgVideoPlayer;
    bool isQHD;
    public RawImage targetTexture;

    public static List<string> backgroundsList;
    public void Initialize()
    {
        DontDestroyOnLoad(this);
        ListInitialize();
        FindVideoAndTexture();
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (Screen.height < 2000 && Screen.width < 2000)
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

    private void FindVideoAndTexture()
    {
        try
        {
            bgVideoPlayer = GetComponent<VideoPlayer>();
            targetTexture = GameObject.FindGameObjectWithTag("Background").GetComponent<RawImage>();
        }
        catch
        {
            Debug.Log("Video And Texture not found");
        }
        
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
            "prologue",
            "Wardrobe",
            "dream",
        };
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        FindVideoAndTexture();
        switch (scene.buildIndex)
        {
            case 1:
                {
                    
                    ChangeBackground("prologue");
                    StartCoroutine(PlayVideo());
                    break;
                }
        }
    }
}
