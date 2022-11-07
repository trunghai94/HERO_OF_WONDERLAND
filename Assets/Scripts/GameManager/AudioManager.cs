using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : Singleton<AudioManager>
{
    public Sound[] BackgroundMusic;
    public Sound[] SoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        CreateAudioSound(BackgroundMusic);
        CreateAudioSound(SoundEffect);
    }
   

    private void CreateAudioSound(Sound[] sounds)
    {
        foreach(Sound sound in sounds)
        {
            sound.sound = gameObject.AddComponent<AudioSource>();
            sound.sound.clip = sound.clip;
            sound.sound.loop = sound.loop;
        }
    }
    public void PlayBGMusic(string soundName)
    {
        Sound sound = Array.Find(BackgroundMusic, itemt => itemt.name == soundName);
        if(sound==null)
        {
            Debug.LogWarning("Sound: " + soundName + "Not Found");
        }
        sound.sound.volume = sound.volume;
        sound.sound.Play();
    }
    public void PlayEffectMusic(string soundName)
    {
        Sound sound = Array.Find(SoundEffect, itemt => itemt.name == soundName);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + soundName + "Not Found");
        }
        sound.sound.volume = sound.volume;
        sound.sound.Play();
    }
}
