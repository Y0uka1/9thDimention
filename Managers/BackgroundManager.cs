using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BackgroundManager : MonoBehaviour, IManager
{
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    public VideoPlayer bgVideoPlayer;
    bool isQHD;
    public RawImage targetTexture;

    public static List<string> backgroundsList;

    public static string curBackground;
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

    public void ChangeBackground()
    {

        if (isQHD)
            bgVideoPlayer.clip = Resources.Load<VideoClip>("Videos/Background/" + curBackground + "2K");
        else
            bgVideoPlayer.clip = Resources.Load<VideoClip>("Videos/Background/" + curBackground + "2K");
        FindVideoAndTexture();
        StartCoroutine(PlayVideo());

    }


    public IEnumerator PlayVideo()
    {
        bgVideoPlayer.Stop();
        bgVideoPlayer.Prepare();
        while (!bgVideoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(0.25f);
        }
        Debug.Log("prep");
        targetTexture.texture = bgVideoPlayer.texture;
        if(curBackground=="dream" && Chapter1Events.cmaeraFlyDone==true)
        {
            RectTransform rect = targetTexture.GetComponent<RectTransform>();
            rect.offsetMin = new Vector2(-300, 0);
            rect.offsetMax = new Vector2(1950, 0);
        }
        bgVideoPlayer.Play();
        yield return new WaitForSeconds(0.5f);
        status = ManagerStatus.Online;
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
        ChangeBackground();
    }
}
