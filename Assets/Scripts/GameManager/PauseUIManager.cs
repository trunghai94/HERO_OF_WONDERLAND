using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIManager : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Setting;
    public GameObject YesOrNoRestart;
    public GameObject YesOrNoMenu;



    public void OnClickSettingButton()
    {
        Pause.SetActive(false);
        Setting.SetActive(true);
    }
    public void OnClickBackSettingButton()
    {
        Pause.SetActive(true);
        Setting.SetActive(false);

    }
    public void OnClickYesNoButton()
    {
        Pause.SetActive(false);
        YesOrNoRestart.SetActive(true);
    }
    public void OnClickBackYesNoButton()
    {
        Pause.SetActive(true);
        YesOrNoRestart.SetActive(false);
    }
    public void OnClickYesNoButtonMenu()
    {
        Pause.SetActive(false);
        YesOrNoMenu.SetActive(true);
    }
    public void OnClickBackYesNoButtonMenu()
    {
        Pause.SetActive(true);
        YesOrNoMenu.SetActive(false);
    }
}
