using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameAnims : MonoBehaviour
{
    Image img;
    
    public List<Sprite> frames = new List<Sprite>();
    public float fps = 5f;

    int currentFrame;
    float clock = 0;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        clock += Time.deltaTime;
        if (clock >= 1 / fps)
        {
            currentFrame++;
            if (currentFrame == frames.Count)
                currentFrame = 0;
            img.sprite = frames[currentFrame];
            clock = 0;
        }
    }
}
