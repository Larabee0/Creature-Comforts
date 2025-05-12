using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] float depth, speed;
    bool animating = false;
    float clock;

    void Update()
    {
        if (animating)
        {
            clock += Time.deltaTime * speed;
            transform.position = new Vector3(startPos.x, Mathf.Lerp(startPos.y - depth, startPos.y, clock), startPos.z);
            if (clock >= 1f)
            {
                animating = false;
                transform.position = startPos;
            }
        }
    }

    public void Press()
    {
        if (!animating)
        {
            startPos = transform.position;
        }
        animating = true;
        clock = 0;
    }
}
