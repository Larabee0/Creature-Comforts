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

        // scores are equal and equal to 5
        if (mothmanScore == nessieScore && mothmanScore  >= 5)
        {
            bossDraw.SetActive(true);
        } // both less than or equal to four
        else if(mothmanScore <= 4 && nessieScore <= 4)
        {
            bossFail.SetActive(true);
        } // mothman greater than 4 and greater than nessie
        else if(mothmanScore > nessieScore && mothmanScore > 4)
        {
            mothmanImpressed.SetActive(true);
        } // nessie greater than 4 and greater than mothman
        else if(nessieScore > mothmanScore && nessieScore > 4) 
        {
            nessieProud.SetActive(true);
        }
        else // catch all case
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
