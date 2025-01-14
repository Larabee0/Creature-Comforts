using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueInteractor : MonoBehaviour
{
    public bool END = false;
    public AudioSFX sfx;
    public Image bellIcon;
    public Canvas end;
    public Image mothman;
    public Image mothmanHead;
    public Sprite MMnormal;
    public Sprite MMbored;
    public Image mothmanArms;
    public Image nessie;
    public PsudoSceneChange psc;
    public TextScrollingScript tss;
    public int chunk;
    [SerializeField] int line;
    public bool talking = true;
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
        if (chunk == 1)
        {
            nessie.enabled = true;
            bellIcon.enabled = false;
        }
    }

    void PrintLine()
    {
        // splits off name up to and including ':'
        for (; i < ChunkedDialogue.dialogue[chunk][line].Length; i++)
        {
            nameToPrint += ChunkedDialogue.dialogue[chunk][line][i];
            if (ChunkedDialogue.dialogue[chunk][line][i] == ':')
            {
                i++;
                break;
            }
        }
        for (; i < ChunkedDialogue.dialogue[chunk][line].Length; i++)
        {
            // look for questions 
            if (ChunkedDialogue.dialogue[chunk][line][i] == '@')
            {
                questionLinks.Add(ChunkedDialogue.dialogue[chunk][line][i+1] - '0'); // Doesn't work for chunk id's > 9
                question = true;
                i++;
            }

            // compose string
            else
            {
                textToPrint += ChunkedDialogue.dialogue[chunk][line][i];
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
            // if last line
            if (!question && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && line == ChunkedDialogue.dialogue[chunk].Count - 1)
            {
                talking = false;
                mothman.enabled = false;
                mothmanArms.enabled = false;
                mothmanHead.enabled = false;
                nessie.enabled = false;
                if (chunk == 1)
                {
                    end.enabled = true;
                    END = true;
                }
            }

            // if normal line
            else if (!question && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) &&
                     textToPrint != " You better answer that bell." &&
                     textToPrint != " I’m on a business trip so will be quite vacant this week, regardless I expect timely service." &&
                     textToPrint != " Maybe I’ll tell you about it next time… I’ll see you around, ok? Thanks again!" &&
                     textToPrint != " Aren’t you going to get that?" &&
                     textToPrint != " That’s why we are called Foggy Lake." &&
                     textToPrint != " Hmm, how pleasant.")
            {
                line++;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
            }

            // if question
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

            // specific line interactions
            else if (textToPrint == " You better answer that bell.")
            {
                if (psc.UDVal == 2 && psc.LRVal == 1 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
                {
                    line++;
                    question = false;
                    nameToPrint = "";
                    textToPrint = "";
                    i = 0;
                    questionLinks.Clear();
                    PrintLine();
                    bellIcon.enabled = false;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    line++;
                    question = false;
                    nameToPrint = "";
                    textToPrint = "";
                    i = 0;
                    questionLinks.Clear();
                    PrintLine();
                    psc.UDVal = 2;
                    psc.LRVal = 1;
                    psc.UpdateCanvass();
                    bellIcon.enabled = false;
                }
            }
            else if (textToPrint == " I’m on a business trip so will be quite vacant this week, regardless I expect timely service." && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                mothman.enabled = false;
                mothmanArms.enabled = false;
                mothmanHead.enabled = false;
                line++;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
            }
            else if (textToPrint == " Maybe I’ll tell you about it next time… I’ll see you around, ok? Thanks again!" && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                nessie.enabled = false;
                line++;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
            }
            else if (textToPrint == " That’s why we are called Foggy Lake." && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                line++;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
                mothmanHead.sprite = MMbored;
            }
            else if (textToPrint == " Hmm, how pleasant." && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                line++;
                question = false;
                nameToPrint = "";
                textToPrint = "";
                i = 0;
                questionLinks.Clear();
                PrintLine();
                mothmanHead.sprite = MMnormal;
            }
        }
    }
}
