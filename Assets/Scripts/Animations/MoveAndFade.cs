using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAndFade : MonoBehaviour
{
    public Transform startPoint, endPoint;
    [SerializeField] float speed, minScale, maxScale;
    Image img;
    float clock;
    bool playing;

    void Start()
    {
        img = GetComponent<Image>();
        img.color = Color.clear;
    }

    public void StartAnim()
    {
        playing = true;
        clock = 0;
    }

    void Update()
    {
        if (playing)
        {
            clock += Time.deltaTime / speed;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, clock);
            img.color = Color.Lerp(Color.white, Color.clear, clock);
            transform.localScale = Vector3.Lerp(new Vector3(minScale, minScale, 1), new Vector3(maxScale, maxScale, 1), clock);
        }
    }
}
