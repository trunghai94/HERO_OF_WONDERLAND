using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIManager : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Setting;



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
}
