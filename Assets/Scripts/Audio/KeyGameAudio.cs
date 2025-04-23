using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGameAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip pickUp,
                     place;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickup()
    {
        audioSource.clip = pickUp;
        audioSource.Play();
    }

    public void PlayPlace()
    {
        audioSource.clip = place;
        audioSource.Play();
    }
}
