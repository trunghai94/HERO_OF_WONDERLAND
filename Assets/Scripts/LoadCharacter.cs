using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LoadCharacter : SingletonMonoBehaviour<LoadCharacter>
{
    public GameObject[] characterPrefabs;
    public CinemachineFreeLook cineCamera;
    public Transform spawnPoint;
    

    public void CreateCharacter()
    {
        if (cineCamera == null) cineCamera = FindObjectOfType<CinemachineFreeLook>();
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<CharacterAiming>().enabled = true;
        clone.GetComponent<PlayerFighter>().enabled = true;
        clone.GetComponent<PlayerStats>().enabled = true;
        clone.GetComponent<XPstat>().enabled = true;
        cineCamera.Follow.SetParent(clone.transform);
        cineCamera.LookAt.SetParent(GameObject.Find("CameraLookAt").transform);
        
    }

}
