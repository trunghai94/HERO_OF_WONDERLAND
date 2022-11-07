using System;
using UnityEngine;
[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 0.75f;
    public bool loop = false;
    [HideInInspector]
    public AudioSource sound;
}
