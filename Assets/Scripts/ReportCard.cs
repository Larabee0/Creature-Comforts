using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportCard : MonoBehaviour
{

    [SerializeField] private GradeBar mothmanGradeBar;
    [SerializeField] private GradeBar nessieGradeBar;
    [SerializeField] private GameObject mothmanImpressed;
    [SerializeField] private GameObject nessieProud;
    [SerializeField] private GameObject bossDraw;
    [SerializeField] private GameObject bossFail;

    public void SetCard(int mothmanScore, int nessieScore)
    {
        gameObject.SetActive(true);
        DisableCharacterImages();

        mothmanGradeBar.SetFill(mothmanScore);
        nessieGradeBar.SetFill(nessieScore);

        if(mothmanScore == nessieScore && mothmanScore  == 5)
        {
            bossDraw.SetActive(true);
        }
        else if(mothmanScore <= 4 && nessieScore <= 4)
        {
            bossFail.SetActive(true);
        }
        else if(mothmanScore > nessieScore && mothmanScore > 4)
        {
            mothmanImpressed.SetActive(true);
        }
        else if(nessieScore > mothmanScore && nessieScore > 4)
        {
            nessieProud.SetActive(true);
        }
        else
        {
            bossDraw.SetActive(true);
        }
    }

    private void DisableCharacterImages()
    {
        mothmanImpressed.SetActive(false);
        nessieProud.SetActive(false);
        bossDraw.SetActive(false);
        bossFail.SetActive(false);
    }
}
