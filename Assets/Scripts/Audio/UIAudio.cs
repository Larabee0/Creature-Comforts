using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip menuButton,
                     correctChoice,
                     incorrectChoice;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMenuButton()
    {
        audioSource.clip = menuButton;
        audioSource.Play();
    }

    public void PlayCorrectChoice()
    {
        audioSource.clip = correctChoice;
        audioSource.Play();
    }

    public void PlayIncorrectChoice()
    {
        audioSource.clip = incorrectChoice;
        audioSource.Play();
    }
}
