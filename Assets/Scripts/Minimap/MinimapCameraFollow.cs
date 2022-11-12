using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraFollow : MonoBehaviour
{
    [SerializeField] private MinimapSetting settings;
    [SerializeField] private float cameraHeight;

    private void Awake()
    {
        settings = GetComponentInParent<MinimapSetting>();
        cameraHeight = transform.position.y;
    }

    private void Update()
    {
        Vector3 targetPosition = settings.targetFollow.transform.position;
        transform.position = new Vector3(targetPosition.x, targetPosition.y + cameraHeight, targetPosition.z);
        if (settings.rotateWithTheTarget)
        {
            Quaternion targetRotation = settings.targetFollow.transform.rotation;
            transform.rotation = Quaternion.Euler(90, targetRotation.eulerAngles.y, 0);
        }
    }
}
