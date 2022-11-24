using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public CinemachineFreeLook cineCamera;
    public Transform spawnPoint;
    public LoadImage loadImage;
    public GameObject gameObject;

    void Awake()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        gameObject = clone;
        clone.GetComponent<CharacterAiming>().enabled = true;
        clone.GetComponent<PlayerFighter>().enabled = true;
        cineCamera.Follow.SetParent(clone.transform);
        cineCamera.LookAt.SetParent(GameObject.Find("CameraLookAt").transform);
        //MinimapSetting.instance.targetFollow = clone.transform;
    }

}
