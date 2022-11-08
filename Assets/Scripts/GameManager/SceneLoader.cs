using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class SceneLoader : MonoBehaviour
{

    public GameObject LoadingScene;
    public GameObject MainMenu;
    public Slider LoadingSlider;
    public Text text;

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

        text.text = " " + Mathf.Round(LoadingSlider.value * 100)+" %";
    }
    public void LoadLevel(string sceneName)
    {
        MainMenu.SetActive(false);
        LoadingScene.SetActive(true);
        StartGame = true;
        StartCoroutine(LevelLoader(sceneName));

    }
    IEnumerator LevelLoader(string sceneName)
    {
        yield return new WaitForSeconds(9.9f);
        SceneManager.LoadScene(sceneName);
        
       
    }
}
