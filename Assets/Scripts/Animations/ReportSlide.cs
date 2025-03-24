using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportSlide : MonoBehaviour
{
    public Transform hand, 
                     report, 
                     startPoint, 
                     endPoint;

    public float moveInSpeed, moveOutSpeed;
    float clock;

    bool moving = false;
    private void Update()
    {
        if (moving)
        {
            if (clock < 1)
            {
                clock += Time.deltaTime * moveInSpeed;
                Vector3 pos = Vector3.Lerp(startPoint.position, endPoint.position, clock);
                hand.position = pos;
                report.position = pos;
            }
            else if (clock > 1)
            {
                clock += Time.deltaTime * moveOutSpeed;
                Vector3 pos = Vector3.Lerp(endPoint.position, startPoint.position, clock - 1);
                hand.position = pos;
                report.position = endPoint.position;
            }
            if (clock >= 2)
            {
                moving = false;
            }
        }
    }

    public void SlideReport()
    {
        moving = true;
        clock = 0;
    }
}
