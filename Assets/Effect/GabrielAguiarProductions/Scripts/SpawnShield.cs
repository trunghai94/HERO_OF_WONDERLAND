using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShield : MonoBehaviour
{
    public static SpawnShield instance;
    public float delayToDestroy = 5;
    public GameObject shieldVFX;
    public GameObject groundCrack;
    public Vector3 shieldOffset;
    public Vector3 groundOffset;

    private void Start()
    {
        instance = this;
    }

    public void spawnShied()
    {
        var vfx = Instantiate(shieldVFX, this.transform) as GameObject;
        var groundVfx = Instantiate(groundCrack,this.transform) as GameObject;
        vfx.transform.SetParent(this.gameObject.transform);
        vfx.transform.position += shieldOffset;
        groundVfx.transform.position += groundOffset;
        Destroy(vfx, delayToDestroy);
        Destroy(groundVfx,delayToDestroy);
    }
}
