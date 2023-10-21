using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        PlayMusic("BackGroundMusic");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, c => c.name == name);
        if(s == null)
        {
            Debug.Log("Can't find the music");

        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }

    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, c => c.name == name);
        if(s == null)
        {
            Debug.Log("Can't find the SFX");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
}
