﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    Image loadScreen;
    AsyncOperation loadLevel;
    public bool isLoading;
    private void Awake()
    {
        loadScreen = GameObject.Find("LoadScreen").GetComponent<Image>();
    }
    private void Start()
    {
        DontDestroyOnLoad(GameObject.Find("LoadingCanvas"));      
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(FirstLoadFunc());
    }

    IEnumerator FirstLoadFunc()
    {
        isLoading = true;
        loadLevel = SceneManager.LoadSceneAsync("MainScene");

        while (!loadLevel.isDone)
            yield return null;

        MainManager mainManager = ScriptableObject.CreateInstance(typeof(MainManager)) as MainManager;
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
        StartCoroutine(MainManager.textManager.ShowText(MainManager.scene1Text.GetReplica()));
    }

    public void LoadLevelById(int id)
    {
        StartCoroutine(LoadFunc(id));
    }

    public IEnumerator Fade(IEnumerator courotine)
    {
        loadScreen.enabled = true;
        yield return StartCoroutine(Tools.MakeTransparent(loadScreen, 1f, false));

        yield return StartCoroutine(courotine);

        yield return StartCoroutine(Tools.MakeTransparent(loadScreen, 1f, true));
        loadScreen.enabled = false;
    }

}
