using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : Singleton<MainUIManager>
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map1");
        
        StartCoroutine(RestartGame());
    }
    public void OnClickBackToMenuButton()
    {
        SceneLoader.Instance.LoadReturmScene();
        SceneLoader.Instance.LoadLevelMenu("Menu");
        pausePanel.SetActive(false);
    }
    public void ShowUIWinGame()
    {
        
    }
    public void ShowUILooseGame()
    {
        LosePanrl.SetActive(true);
        Time.timeScale = 0f;
        freelockCamera.SetActive(false);
    }
   
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1f);
        pausePanel.SetActive(false);
    }
}
