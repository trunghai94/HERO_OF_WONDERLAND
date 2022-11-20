using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : SingletonMonoBehaviour<MainUIManager>
{
    public GameObject continueButton;
    public GameObject pausePanel;
    public GameObject freelockCamera;
    public GameObject LosePanrl;
    
   
    public void OnClickPauseButton()
    {
       pausePanel.SetActive(true);
       Time.timeScale = 0f;
       freelockCamera.SetActive(false);

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
        freelockCamera.SetActive(true);
    }
    public void OnRestartGameButton()
    {
        var scene = SceneManager.LoadSceneAsync("Map1");
        StartCoroutine(RestartGaneWhenLose(scene.progress, pausePanel));
    }
    public void OnClickBackToMenuButton(string scenename)
    {
        LevelManager.Instance.LoadScene(scenename);
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    public void ShowUIWinGame()
    {
       
    }
    public void OnClickRestartLoseButton()
    {
        
       var scene= SceneManager.LoadSceneAsync("Map1");
        StartCoroutine(RestartGaneWhenLose(scene.progress,LosePanrl));        
    }
    public void ShowUILooseGame()
    {
        LosePanrl.SetActive(true);
        Time.timeScale = 0f;
        freelockCamera.SetActive(false);
    }
    IEnumerator RestartGaneWhenLose(float time, GameObject Panel)
    {
        yield return new WaitForSeconds(time);
        Panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
