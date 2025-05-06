using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportSlide : MonoBehaviour
{
    public Transform hand, 
                     report, 
                     startPoint, 
                     endPoint;

    public float moveInSpeed, moveOutSpeed;

    public Image finalGrade, bossQoute;
    public List<Sprite> gradeImgs = new List<Sprite>(), 
                        bossQoutes = new List<Sprite>();

    float clock;

    bool moving = false;

    [SerializeField] private ReportCard finalReport;
    [SerializeField] private GameObject dayReport;
    [SerializeField] private GeneralAudio generalAudio;

    public GameState gs;

    private void Start()
    {
        finalReport.gameObject.SetActive(false);
        dayReport.SetActive(true);
    }

    private void Update()
    {
        if (moving)
        {
            if (clock <= 1)
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
            if (clock >= 10)
            {
                moving = false;
                gs.UpdateGamestate();
            }
        }
    }

    public void SlideReport()
    {
        generalAudio.PlayPaperSlide();
        moving = true;
        clock = 0;
    }

    public void ResetReport()
    {
        clock = 0;
        moving = false;
        report.position = startPoint.position;
        gs.gradeList.Clear();
        finalReport.gameObject.SetActive(false);
        dayReport.SetActive(true);
    }

    public void SlideFinalReport()
    {
        finalReport.SetCard(gs.mothmanSentiment, gs.nessieSentiment);
        dayReport.SetActive(false);
        SlideReport();
    }
}
