using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bell2frame : MonoBehaviour
{
    float timer;
    [SerializeField] float timeToSwitch;
    int frame = 0;
    public Sprite frame0;
    public Sprite frame1;
    Image img;

    private void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSwitch)
        {
            timer -= timeToSwitch;
            frame = frame == 0 ? 1 : 0;
            img.sprite = frame == 0 ? frame0 : frame1;
        }
    }
}
