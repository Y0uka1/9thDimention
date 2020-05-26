using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    Image loadScreen;
    AsyncOperation loadLevel;
    public bool isLoading;
    private void Start()
    {
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        loadScreen = GameObject.Find("LoadScreen").GetComponent<Image>();
       // DontDestroyOnLoad(loadScreen.gameObject);
        DontDestroyOnLoad(this.gameObject);
        //SceneManager.activeSceneChanged += OnSceneChange;
       // SceneManager.sceneLoaded += OnSceneLoaded;
        StartCoroutine(FirstLoadFunc());
    }

    IEnumerator FirstLoadFunc()
    {
        isLoading = true;
        loadLevel = SceneManager.LoadSceneAsync("MainScene");

        while (!loadLevel.isDone)
            yield return null;

        MainManager mainManager = ScriptableObject.CreateInstance(typeof(MainManager)) as MainManager;
        //MainManager mainManager = Instantiate(Resources.Load<GameObject>("Manager")).GetComponent<MainManager>();
        //DontDestroyOnLoad(mainManager.gameObject);
        mainManager.Initialize();
        while (mainManager.status != ManagerStatus.Online)
        {
            yield return new WaitForSeconds(0.3f);
        }

        yield return new WaitForSeconds(1.5f);

        yield return  StartCoroutine(Tools.MakeTransparent(loadScreen, 1f, true));

        loadScreen.enabled = false;
        loadScreen.color = new Color(0,0,0,0);
        isLoading = false;
        MainManager.textManager.OnLevelLoad();
    }

   public IEnumerator LoadFunc(int leveIndex)
    {
        isLoading = true;
        loadScreen.enabled = true;
        loadLevel = SceneManager.LoadSceneAsync(leveIndex);
        loadLevel.allowSceneActivation = false;
        yield return StartCoroutine(Tools.MakeTransparent(loadScreen, 1f, false));
       
       
        while (loadLevel.progress < 0.9f)
            yield return null;

        loadLevel.allowSceneActivation = true;
        yield return new WaitForSeconds(1.5f);
       
        yield return StartCoroutine(Tools.MakeTransparent(loadScreen, 1f, true));
        loadScreen.enabled = false;
        isLoading = false;
    }

    public void LoadLevelById(int id)
    {
        StartCoroutine(LoadFunc(id));
    }

    public IEnumerator Fade()
    {
        loadScreen.enabled = true;
        yield return StartCoroutine(Tools.MakeTransparent(loadScreen, 1f, false));

       

        yield return new WaitForSeconds(1.5f);

        yield return StartCoroutine(Tools.MakeTransparent(loadScreen, 1f, true));
        loadScreen.enabled = false;
    }

}
