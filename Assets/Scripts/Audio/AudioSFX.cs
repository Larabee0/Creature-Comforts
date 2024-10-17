using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFX : MonoBehaviour
{
    public AudioClip bell;
    public AudioClip phone;
    AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void StopAudio()
    {
        aud.Stop();
    }

    public void Bell()
    {
        aud.loop = false;
        aud.clip = bell;
        aud.Play();
    }
}
