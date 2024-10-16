using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tut_DialogueInteractor : MonoBehaviour
{
    public Image jeremy;
    public DialogueInteractor di;
    public Wiggle phon;
    public PsudoSceneChange psc;
    public Tut_TextScrollingScript tss;
    public int chunk;
    [SerializeField] int line;
    public bool talking = false;
    bool question = false;
    int i = 0;
    [SerializeField] List<int> questionLinks = new List<int>();
    public bool pause = false;

    [SerializeField]string nameToPrint = "";
    [SerializeField]string textToPrint = "";

    private void Start()
    {
        StartTalking(0);
    }

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
            if (textToPrint != " The phone on your desk is ringing. It’s probably your boss." && 
                textToPrint != " Press DOWN ARROW to switch to the computer screen." && 
                textToPrint != " Press the UP ARROW to switch back to the desk." && 
                textToPrint != " press the UP ARROW to greet anyone that decides to come to the desk" &&
                textToPrint != " Did you catch all of that? Don’t worry, it’s all on the board if you forget." &&
                textToPrint != " I’ll be back at the end of your shift to evaluate your performance. Have a good day!" &&
                !question && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                line++;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
            }

            else if (question)
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

            // FOR SPECIFIC INPUTS
            else if (textToPrint == " Press DOWN ARROW to switch to the computer screen." && Input.GetKeyDown(KeyCode.DownArrow))
            {
                chunk = 1;
                line = 0;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
                psc.LRVal = 1;
                psc.UDVal = 0;
                psc.UpdateCanvass();
            }
            else if (textToPrint == " The phone on your desk is ringing. It’s probably your boss." && !phon.wiggling)
            {
                line = 1;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
            }
            else if (textToPrint == " Press the UP ARROW to switch back to the desk." && Input.GetKeyDown(KeyCode.UpArrow))
            {
                chunk = 2;
                line = 0;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
                psc.LRVal = 1;
                psc.UDVal = 1;
                psc.UpdateCanvass();
            }
            else if (textToPrint == " press the UP ARROW to greet anyone that decides to come to the desk" && Input.GetKeyDown(KeyCode.UpArrow))
            {
                chunk = 3;
                line = 0;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
                psc.LRVal = 1;
                psc.UDVal = 2;
                psc.UpdateCanvass();
            }
            else if (textToPrint == " Did you catch all of that? Don’t worry, it’s all on the board if you forget." && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                line++;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
                jeremy.enabled = false;
                psc.LRVal = 1;
                psc.UDVal = 1;
                psc.UpdateCanvass();
            }
            else if (textToPrint == " I’ll be back at the end of your shift to evaluate your performance. Have a good day!" && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                talking = false;
                di.StartTalking(0);
                psc.tutorial = false;
            }
        }
    }
}
