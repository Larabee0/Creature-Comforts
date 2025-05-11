using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    float fadeSpeed;
    float clock = 0;
    public AudioClip currentSong, morning, evening, keyGame;
    public AudioClip target;
    bool fading = false;
    bool startedPlaying = false;
    public bool autoPlay = false;
    AudioSource musicSource;

    public void SwapSong()
    {
        fading = true;
        startedPlaying = false;
        clock = 0;
    }

    public void FadeTo(AudioClip song)
    {
        if(currentSong == song) return;
        target = song;
        fading = true;
        startedPlaying = false;
        clock = 0;
    }

    void Start()
    {
        musicSource = gameObject.GetComponent<AudioSource>();
        if (autoPlay)
        {
            musicSource.clip = evening;
            musicSource.Play();
        }
    }

    void Update()
    {
        if (fading)
        {
            clock += Time.deltaTime * fadeSpeed;
            
            if (clock <= 0.5f)
            {
                musicSource.volume = Mathf.Lerp(SettingsScript.musicVolume, 0f, clock * 2);
            }
            else
            {
                if (!startedPlaying)
                {
                    musicSource.clip = currentSong = target;
                    target = null;
                    musicSource.Play();
                    startedPlaying = true;
                }
                musicSource.volume = Mathf.Lerp(0f, SettingsScript.musicVolume, (clock - 0.5f) * 2);
            }
        }    
    }
}
