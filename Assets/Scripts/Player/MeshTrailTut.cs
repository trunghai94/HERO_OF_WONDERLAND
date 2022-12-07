using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrailTut : MonoBehaviour
{
    public float activeTime = 2f;

    [Header("Mesh Related")]
    public float meshRefreshRate = 0.1f;
    public float meshDestroyDelay = 3f;
    public Transform positionToSpawn;
    //public AudioClip audioClip;

    [Header("Shader Related")]
    public Material mat;
    public string shaderVarRef;
    public float shaderVarRate = 0.1f;
    public float shaderVarRefreshRate = 0.05f;


    private bool isTrailActive;
    private SkinnedMeshRenderer[] skinnedMeshRenderer;
    private PlayerMovement playerMovement;
    private AudioSource audioSource;
 
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerMovement.isSprint == true && !isTrailActive)
        {
            isTrailActive = true;
            StartCoroutine(ActiveTrail(activeTime));
        }
    }

    IEnumerator ActiveTrail(float timeActive)
    {
        while(timeActive > 0) 
        {
            timeActive -= meshRefreshRate;

            if(skinnedMeshRenderer == null)
                skinnedMeshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();
            
            for (int i = 0; i< skinnedMeshRenderer.Length; i++)
            {
                GameObject gobj = new GameObject();
                gobj.layer = 3;
                gobj.transform.SetPositionAndRotation(positionToSpawn.position, positionToSpawn.rotation);
                MeshRenderer mr = gobj.AddComponent<MeshRenderer>();
                MeshFilter mf = gobj.AddComponent<MeshFilter>();

                Mesh mesh = new Mesh();
                skinnedMeshRenderer[i].BakeMesh(mesh);

                mf.mesh = mesh;
                mr.material = mat;

                StartCoroutine(AnimateMaterialFloat(mr.material, 0, shaderVarRate, shaderVarRefreshRate));

                Destroy(gobj, meshDestroyDelay);
            }

            yield return new WaitForSeconds(meshRefreshRate);
        }
        isTrailActive = false;
    }

    IEnumerator AnimateMaterialFloat(Material mat, float goat, float rate, float refredRate)
    {
        float valueToAnimate = mat.GetFloat(shaderVarRef);

        while(valueToAnimate > goat)
        {
            valueToAnimate -= rate;
            mat.SetFloat(shaderVarRef, valueToAnimate);
            yield return new WaitForSeconds(refredRate);
        }
    }
}
