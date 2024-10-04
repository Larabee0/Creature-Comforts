using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChunkedDialogue
{
    public static List<List<string>> dialogue = new List<List<string>>()
    {
        new List<string>()
        {
            "Mothman: Says something witty.",
            "Player: Reacts apropriately",
            "Mothman: Asks a question",
            "Player: @1 1.yes @2 2.no"
        }
    };
}
