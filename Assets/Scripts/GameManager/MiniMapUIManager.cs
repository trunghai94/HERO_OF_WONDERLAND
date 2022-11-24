using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapUIManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject losePanel;
    public GameObject MiniMap;
    public GameObject map;
    public bool isPausePanelActive;
    public bool isLosePanelAsctive;
    public bool isMiniMaplAsctive;
    public bool isMapActive;


    // Update is called once per frame
    void Update()
    {
        if (PausePanel.activeSelf || losePanel.activeSelf) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MiniMap.activeSelf)
            {
                MiniMap.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isMapActive = true;
            ActiveMinimap(isMapActive);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            isMapActive = false;
            ActiveMinimap(isMapActive);
        }
    }

    void ActiveMinimap(bool isActive)
    {
        if (!map.activeSelf)
        {
            MiniMap.SetActive(!isActive);
            map.SetActive(isActive);
        }
        else
        {
            MiniMap.SetActive(isActive);
            map.SetActive(!isActive);
        }   
    }
}
