using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextBox : MonoBehaviour
{
    public Tut_DialogueInteractor tutDia;
    public DialogueInteractor dia;

    public Image img;
    public TextMeshProUGUI tmp;

    void Update()
    {
        if (dia.talking || tutDia.talking)
        {
            img.enabled = true;
            tmp.enabled = true;
        }

        else
        {
            img.enabled = false;
            tmp.enabled = false;
        }
    }
}
