using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{

    public GameObject LoadingScene;
    public GameObject MainMenu;
    public Slider LoadingSlider;
    public Text text;
    public GameObject Canvas;

    private float LoadingValue;
    private float timeLoading;
    private bool StartGame=false;
    private void Update()
    {
        if (StartGame)
        {
            timeLoading += Time.deltaTime * 0.1f;
            
        }
        LoadingSlider.value = timeLoading;

        text.text = " " + Mathf.Round(LoadingSlider.value * 100) + " %";
    }
    public void LoadLevel(string sceneName)
    {
        MainMenu.SetActive(false);
        LoadingScene.SetActive(true);
        StartGame = true;
        StartCoroutine(LevelLoader(sceneName));

    }
    public void LoadLevelMenu(string sceneName)
    {
        MainMenu.SetActive(true);
        LoadingScene.SetActive(false);
        StartGame = true;

        StartCoroutine(LevelLoader(sceneName));

    }
    IEnumerator LevelLoader(string sceneName)
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(sceneName);
        Canvas.SetActive(false);
    }
    public void LoadReturmScene()
    {
        Canvas.SetActive(true);
    }
}
