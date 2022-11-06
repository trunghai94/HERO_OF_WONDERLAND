using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{

    public GameObject LoadingScene;
    public GameObject MainMenu;
    public Slider LoadingSlider;
    public Text text;
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LevelLoader(sceneName));
    }
    IEnumerator LevelLoader(string sceneName)
    {
       
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        MainMenu.SetActive(false);
        LoadingScene.SetActive(true);
        

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingSlider.value = progress;
            text.text = progress * 100f+"%"; 
            yield return null;
        }
    }
}
