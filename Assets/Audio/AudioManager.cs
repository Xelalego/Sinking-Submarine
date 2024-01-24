using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource levelMusic;
    public AudioSource[] sfx;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayLevelMusic()
    {
        if (!levelMusic.isPlaying)
        {
            levelMusic.Play();
        }
    }

    public void PlaySFX(int sfxToPlay)
    {
        // Stop sfx if already playing.
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }

    // Prevent hearing sounds constantly being played back-to-back
    // and going deafening volumes.
    public void PlaySFXAdjusted(int sfxToAdjust)
    {
        sfx[sfxToAdjust].pitch = Random.Range(.8f, 1.2f);
        PlaySFX(sfxToAdjust);
    }
}
