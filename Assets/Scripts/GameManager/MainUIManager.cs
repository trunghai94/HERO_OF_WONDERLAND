using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class MainUIManager : SingletonMonoBehaviour<MainUIManager>
{
    public GameObject continueButton;
    public GameObject pausePanel;
    public GameObject MiniMap;
    public GameObject HPBar;
    public GameObject LosePanrl;
    [HideInInspector]
    public CinemachineFreeLook freelockCam;
    public Image frontXPBar;
    public Image backXPBar;
    public Image hpImg;
    public TextMeshProUGUI textLv;
    
    public void OnClickPauseButton()
    {
        if (freelockCam == null) freelockCam = LoadCharacter.Instance.cineCamera;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
       
        HPBar.SetActive(false);
        freelockCam.m_XAxis.m_InputAxisName = string.Empty;
        freelockCam.m_YAxis.m_InputAxisName = string.Empty;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

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
        if (!MiniMap.activeSelf)
        {
            MiniMap.SetActive(true);
        }
        Time.timeScale = 1f;
        
        HPBar.SetActive(true);
        freelockCam.m_XAxis.m_InputAxisName = "Mouse X";
        freelockCam.m_YAxis.m_InputAxisName = "Mouse Y";
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        HPBar.SetActive(false);
        freelockCam.m_XAxis.m_InputAxisName = string.Empty;
        freelockCam.m_YAxis.m_InputAxisName = string.Empty;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

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

    public void OnClickedStartGame()
    {
        HPBar.SetActive(true);
        MiniMap.SetActive(true);
    }
}
