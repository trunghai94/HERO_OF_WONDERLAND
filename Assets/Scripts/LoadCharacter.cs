using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public CinemachineFreeLook cineCamera;
    public Transform spawnPoint;

    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<CharacterAiming>().enabled = true;
        clone.GetComponent<PlayerFighter>().enabled = true;
        cineCamera.Follow.SetParent(clone.transform);
        cineCamera.LookAt.SetParent(GameObject.Find("CameraLookAt").transform);
    }

}
