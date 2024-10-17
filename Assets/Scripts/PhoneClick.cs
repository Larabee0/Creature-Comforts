using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneClick : MonoBehaviour, IPointerClickHandler
{
    public AudioSFX a;
    public Tut_DialogueInteractor interactor;
    public Wiggle wiggle;

    public void OnPointerClick(PointerEventData eventData)
    {
        wiggle.SetWiggling(false);
        a.StopAudio();
    }
}
