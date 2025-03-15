using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private static AudioManager instance;

    public void Awake() {
        if (instance != null) {
            Debug.Log("Audio Manager already exists.");
            return;
        }

        instance = this;
    }

    public static AudioManager GetInstance() {
        return instance;
    }

    public void Start() {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name) {
        Sound s = Array.Find(musicSounds, x => x.soundName == name);

        if (s == null) {
            Debug.Log("Music sounce Not Found");
            return;
        }

        musicSource.clip = s.clip;
        musicSource.Play();

    }

    public void PlaySFX(string name) {
        Sound s = Array.Find(sfxSounds, x => x.soundName == name);

        if (s == null) {
            Debug.Log("Music sounce Not Found");
            return;
        }

        sfxSource.clip = s.clip;
        sfxSource.Play();
    }


}
