using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameAnims : MonoBehaviour
{
    SpriteRenderer img;
    
    public List<Sprite> frames = new List<Sprite>();
    public float fps = 10f;

    private void Start()
    {
        img = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        img.sprite = frames[0];
    }
}
