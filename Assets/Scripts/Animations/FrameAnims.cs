using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameAnims : MonoBehaviour
{
    Sprite img;
    
    public List<Image> frames = new List<Image>();
    public float fps = 10f;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        img.texture = frames[0];
    }
}
