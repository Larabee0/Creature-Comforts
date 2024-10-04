using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInterpreter : MonoBehaviour
{
    public unsafe string GetText(bool* question, int chunk, int line)
    {
        string gotString = ChunkedDialogue.dialogue[chunk][line];
        if (gotString.Contains("@"))
        {
            *question = true;
        }
        return "";
    }
}
