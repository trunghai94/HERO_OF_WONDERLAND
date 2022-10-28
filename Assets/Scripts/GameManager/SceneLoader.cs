using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator TransitionAnim;
    public float tranSitionTime;
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LevelLoader(sceneName));
    }
    IEnumerator LevelLoader(string sceneName)
    {
        TransitionAnim.SetTrigger("loadscene");
        yield return new WaitForSeconds(tranSitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
