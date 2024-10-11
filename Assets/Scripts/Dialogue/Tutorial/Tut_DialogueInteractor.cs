using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tut_DialogueInteractor : MonoBehaviour
{
    public Tut_TextScrollingScript tss;
    public int chunk;
    [SerializeField] int line;
    public bool talking = false;
    bool question = false;
    int i = 0;
    [SerializeField] List<int> questionLinks = new List<int>();
    public bool pause = false;

    string nameToPrint = "";
    string textToPrint = "";

    public void StartTalking(int Chunk)
    {
        chunk = Chunk;
        line = 0;
        talking = true;
        question = false;
        nameToPrint = "";
        textToPrint = "";
        i = 0;
        questionLinks.Clear();
        PrintLine();
    }

    void PrintLine()
    {
        for (; i < Tut_ChunkedDialogue.dialogue[chunk][line].Length; i++)
        {
            nameToPrint += Tut_ChunkedDialogue.dialogue[chunk][line][i];
            if (Tut_ChunkedDialogue.dialogue[chunk][line][i] == ':')
            {
                i++;
                break;
            }
        }
        for (; i < Tut_ChunkedDialogue.dialogue[chunk][line].Length; i++)
        {
            // look for questions 
            if (Tut_ChunkedDialogue.dialogue[chunk][line][i] == '@')
            {
                questionLinks.Add(Tut_ChunkedDialogue.dialogue[chunk][line][i + 1] - '0'); // Doesn't work for chunk id's > 9
                question = true;
                i++;
            }

            // compose string
            else
            {
                textToPrint += Tut_ChunkedDialogue.dialogue[chunk][line][i];
            }
        }

        tss.ScrollText(nameToPrint, textToPrint);
        pause = true;
    }

    // only for handeling inputs
    private void Update()
    {
        if (talking && !pause)
        {
            if (textToPrint != " Press DOWN ARROW to switch to the computer screen." && !question && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                line++;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
            }

            if (question)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1) && questionLinks.Count >= 1)
                {
                    chunk = questionLinks[0];
                    line = 0;
                    question = false;
                    nameToPrint = "";
                    textToPrint = "";
                    i = 0;
                    questionLinks.Clear();
                    PrintLine();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2) && questionLinks.Count >= 2)
                {
                    chunk = questionLinks[1];
                    line = 0;
                    question = false;
                    nameToPrint = "";
                    textToPrint = "";
                    i = 0;
                    questionLinks.Clear();
                    PrintLine();
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3) && questionLinks.Count >= 3)
                {
                    chunk = questionLinks[2];
                    line = 0;
                    question = false;
                    nameToPrint = "";
                    textToPrint = "";
                    i = 0;
                    questionLinks.Clear();
                    PrintLine();
                }
            }
            if (textToPrint == " Press DOWN ARROW to switch to the computer screen." && Input.GetKeyDown(KeyCode.DownArrow))
            {
                chunk = 1;
                line = 0;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
            }
        }
    }
}
