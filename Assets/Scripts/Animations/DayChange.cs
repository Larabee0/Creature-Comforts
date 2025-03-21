using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayChange : MonoBehaviour
{
    [SerializeField]bool fading = false;
    float clock = 0;
    public float fadeTime, holdTime;
    Image blkScrn;
    TextMeshProUGUI tmp;

    void Start()
    {
        blkScrn = gameObject.GetComponent<Image>();
        tmp = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        tmp.raycastTarget = false;
        blkScrn.color = Color.clear;
        tmp.color = Color.clear;
    }

    void Update()
    {
        if (fading)
        {
            clock += Time.deltaTime;
            if (clock < fadeTime)
            {
                FadeIn();
            }
            else if (clock >= fadeTime + holdTime)
            {
                FadeOut();
                if (clock > fadeTime * 2 + holdTime)
                {
                    fading = false;
                    clock = 0;
                }
            }
        }
    }

    public void StartFade()
    {
        fading = true;
    }

    void FadeIn()
    {
        Color col = Color.Lerp(Color.clear, Color.white, clock / fadeTime);
        blkScrn.color = col;
        tmp.color = col;
    }

    void FadeOut()
    {
        Color col = Color.Lerp(Color.white, Color.clear, (clock - (fadeTime + holdTime)) / fadeTime);
        blkScrn.color = col;
        tmp.color = col;
    }
}
