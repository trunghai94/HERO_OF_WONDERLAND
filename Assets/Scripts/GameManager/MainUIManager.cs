using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : SingletonMonoBehaviour<MainUIManager>
{
    

    public GameObject continueButton;
    public GameObject pausePanel;
    
    public GameObject LosePanrl;

    
    public void OnClickPauseButton()
    {
       pausePanel.SetActive(true);
       Time.timeScale = 0f;
       

    }
    private void Update()
    {
        if (!LosePanrl.activeSelf)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                OnClickPauseButton();
            }
            
        }
        
    }
    public void OnClickContinueButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        
    }
    public void OnRestartGameButton(string sceneName)
    {
        Time.timeScale = 1f;
        var scene = SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(RestartGame(scene.progress, pausePanel));
    }
    public void OnClickBackToMenuButton(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(RestartGame(scene.progress, pausePanel));
    }
    public void ShowUIWinGame()
    {
        
    }
    public void ShowUILooseGame()
    {
        LosePanrl.SetActive(true);
        Time.timeScale = 0f;
        
    }
    public void RestartGameAtLose(string sceneName)
    {
        Time.timeScale = 1f;
        var scene = SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(RestartGame(scene.progress, LosePanrl));
    }
    public void BackToMenuAtLose(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        StartCoroutine(RestartGame(scene.progress, LosePanrl));
    }
   
    IEnumerator RestartGame(float time, GameObject panel)
    {
        yield return new WaitForSeconds(time);
        panel.SetActive(false);
    }
}
