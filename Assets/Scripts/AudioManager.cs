using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public SoundAsset[] soundsGame;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        GameObject.DontDestroyOnLoad(gameObject);

        foreach (SoundAsset sound in soundsGame)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;
            sound.source.volume = sound.volume;
            sound.source.playOnAwake = sound.playOnAwake;
            sound.source.loop = sound.loop;
        }
    }
    public void Play ( string nameSound)
    {
        SoundAsset soundPlay = Array.Find(soundsGame, sound => sound.nameSound == nameSound);
        if (soundPlay == null)
        {
            Debug.LogWarning("Sound :" + nameSound + "missing");
        }
        soundPlay.source.Play();
    }
    public void Stop(string nameSound)
    {
        SoundAsset soundPlay = Array.Find(soundsGame, sound => sound.nameSound == nameSound);
        if (soundPlay == null)
        {
            Debug.LogWarning("Sound :" + nameSound + "missing");
        }
        soundPlay.source.Stop();
    }
}
