using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject pausePanel;
    public GameObject freelockCamera;
    public GameObject Minimap;
    public GameObject Map;
    public GameObject SettingPanel;

    public void OnClickPauseButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        freelockCamera.SetActive(false);       
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
        if (Input.GetKey(KeyCode.Tab))
        {
            if (!pausePanel.activeSelf)
            {
                Time.timeScale = 0;
                Minimap.SetActive(false);
                Map.SetActive(true);
                freelockCamera.SetActive(false);
                
            }            
        }
        else
        {
            Minimap.SetActive(true);
            Map.SetActive(false);
            freelockCamera.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public void OnClickContinueButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        freelockCamera.SetActive(true);
        
    }
    public void OnRestartGameButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Map1");
        StartCoroutine(RestartGame());
    }
    public void OnClickBackToMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnClickSettingButton()
    {
        pausePanel.SetActive(false);
        SettingPanel.SetActive(true);
    }
    public void OnClickSettingback()
    {
        pausePanel.SetActive(true);
        SettingPanel.SetActive(false);
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
