using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject pausePanel;
    public GameObject freelockCamera;

    public void OnClickPauseButton()
    {
        pausePanel.SetActive(true);
        freelockCamera.SetActive(false);
        Time.timeScale = 0f;
        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!pausePanel.activeSelf)
            {
                OnClickPauseButton();
            }
        }
    }
    public void OnClickContinueButton()
    {
        pausePanel.SetActive(false);
        freelockCamera.SetActive(true);
        Time.timeScale = 1f;
    }
    public void OnRestartGameButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Map1");
        StartCoroutine(RestartGame());
    }
    public void OnClickBackToMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void ShowUIWinGame()
    {
        
    }
    public void ShowUILooseGame()
    {
      
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1f);
        pausePanel.SetActive(false);
    }
}
