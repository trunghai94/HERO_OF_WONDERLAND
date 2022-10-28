using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

public class GameManager : Singleton<GameManager>
{
    public SceneLoader SceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void EndGame()
    {
        Time.timeScale = 0f;
    }
    public void ResetState()
    {
        Time.timeScale = 1f;
    }
    public void OnClickStartGame()
    {
        SceneLoader.LoadLevel("Map1");
    }
    public void OnClickExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    private void SetStarVolume()
    {

    }
    private void SetStarQuality()
    {

    }
}
