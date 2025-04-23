using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip paperSlide,
                     bell,
                     phone;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
}
