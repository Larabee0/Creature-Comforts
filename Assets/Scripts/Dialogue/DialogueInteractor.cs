using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueInteractor : MonoBehaviour
{
    public TextScrollingScript tss;
    public int chunk;
    [SerializeField] int line;
    [SerializeField] bool talking;
    bool question = false;
    int answers = 0;
    int i = 0;

    string nameToPrint = "";
    string textToPrint = "";

    public void StartTalking(int Chunk)
    {
        chunk = Chunk;
        line = 0;
        talking = true;
        answers = 0;
        question = false;
    }

    void PrintLine()
    {
        for (; i < ChunkedDialogue.dialogue[chunk][line].Length; i++)
        {
            nameToPrint += ChunkedDialogue.dialogue[chunk][line][i];
            if (ChunkedDialogue.dialogue[chunk][line][i] == ':')
            {
                break;
            }
        }


        tss.ScrollText(nameToPrint, textToPrint);
    }

    // only for handeling inputs
    private void Update()
    {
        if (talking)
        {
            if (!question && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                line++;
            }
        }
    }
}
