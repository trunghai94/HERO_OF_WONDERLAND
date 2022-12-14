using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    public Sound[] backgroundMusic;
    public Sound[] soundEffect;

    private int currentPlayingBGMIndex = 999;
    private bool shouldPlayBGM = false;
    public float bgmVolume;
    public float effectVolume;

    protected override void Awake()
    {
        base.Awake();

        bgmVolume = PlayerPrefs.GetFloat(CONSTANT.PP_VOLUME, CONSTANT.DEFAULT_VOLUME);
        effectVolume = PlayerPrefs.GetFloat(CONSTANT.PP_EFVOLUME, CONSTANT.DEFAULT_EFVOLUME);

    }
    private void Start()
    {
        CreateAudioSource(backgroundMusic, bgmVolume);
        CreateAudioSource(soundEffect, effectVolume);
    }

    void Update() //for 1 bgm
    {
        //if (currentPlayingBGMIndex != 999 && !backgroundMusic[currentPlayingBGMIndex].source.isPlaying)
        //{
        //    currentPlayingBGMIndex++;
        //    if (currentPlayingBGMIndex >= backgroundMusic.Length)
        //    {
        //        currentPlayingBGMIndex = 0;
        //    }
        //    backgroundMusic[currentPlayingBGMIndex].source.Play();
        //}
    }

    private void CreateAudioSource(Sound[] sounds, float volume)
    {
        foreach (Sound sound in sounds)//loop through each bgm/effect
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume * volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void PlayEffect(string name)
    {
        Sound effect = Array.Find(soundEffect, effect => effect.name == name);
        if (effect == null)
        {
            Debug.LogError("Unable to play effect " + name);
            return;
        }
        effect.source.Play();
    }

    public void PlayBackgroudMusic(string name)
    {
        //if (shouldPlayBGM == false)
        //{
        //    shouldPlayBGM = true;
        //    currentPlayingBGMIndex = UnityEngine.Random.Range(0, backgroundMusic.Length - 1);
        //    backgroundMusic[currentPlayingBGMIndex].source.volume = backgroundMusic[currentPlayingBGMIndex].volume * bgmVolume;
        //    backgroundMusic[currentPlayingBGMIndex].source.Play();
        //}
        Sound BGM = Array.Find(backgroundMusic, BGM => BGM.name == name);
        if (BGM == null)
        {
            Debug.LogError("Unable to play effect " + name);
            return;
        }
        BGM.source.Play();
    }

    public void StopBackgroundMusic()
    {
        if (shouldPlayBGM == true)
        {
            shouldPlayBGM = false;
            currentPlayingBGMIndex = 999;
        }
    }

    public string GetBGMName()
    {
        return backgroundMusic[currentPlayingBGMIndex].name;
    }
    

    public void SetBGMVolume(float volume)
    {
        foreach (Sound bgm in backgroundMusic)
        {
            float curBGMVolume = PlayerPrefs.GetFloat(CONSTANT.PP_VOLUME, CONSTANT.DEFAULT_VOLUME);
            if (volume != curBGMVolume)
            {
                bgm.source.volume = volume;
                PlayerPrefs.SetFloat(CONSTANT.PP_VOLUME, volume);
            }
        }
    }

    public void SetEffectVolume(float volume)
    {
        float curEffectVolume = PlayerPrefs.GetFloat(CONSTANT.PP_EFVOLUME, CONSTANT.DEFAULT_EFVOLUME);
        foreach (Sound effect in soundEffect)
        {
            if (volume != curEffectVolume)
            {
                effect.source.volume = volume;
                PlayerPrefs.SetFloat(CONSTANT.PP_EFVOLUME, volume);
            }
        }
    }
}

