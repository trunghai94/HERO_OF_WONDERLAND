using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    private float turnSpeed = 20f;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.deltaTime);
    }
}
