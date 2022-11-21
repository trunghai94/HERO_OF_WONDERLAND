using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapUIManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject losePanel;
    public GameObject MiniMap;
    public GameObject map;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (!PausePanel.activeSelf && !losePanel.activeSelf)
            {
                MiniMap.SetActive(false);
                map.SetActive(true);
            }
        }
        else
        {
            MiniMap.SetActive(true);
            map.SetActive(false);
        }
    }
}
