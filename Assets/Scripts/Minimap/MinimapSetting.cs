using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapSetting : MonoBehaviour
{
    public Transform targetFollow;
    public GameObject PausePanel;
    public GameObject MiniMap;
    public GameObject map;
    public bool rotateWithTheTarget = true;
    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            if(!PausePanel.activeSelf)
            {
                MiniMap.SetActive(false);
                map.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        else
        {
            MiniMap.SetActive(true);
            map.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
