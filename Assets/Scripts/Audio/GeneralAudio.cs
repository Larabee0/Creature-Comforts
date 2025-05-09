using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip paperSlide,
                     bell,
                     phone;
    
    public void PlayPaperSlide()
    {
        audioSource.clip = paperSlide;
        audioSource.Play();
    }

    public void PlayBell()
    {
        audioSource.clip = bell;
        audioSource.Play();
    }

    public void PlayPhone()
    {
        audioSource.clip = phone;
        audioSource.Play();
    }
    public void StopPhone()
    {
        if(audioSource.clip == phone && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
