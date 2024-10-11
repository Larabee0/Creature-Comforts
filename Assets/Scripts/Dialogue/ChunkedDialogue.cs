using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class ChunkedDialogue
{
    public static List<List<string>> dialogue = new List<List<string>>()
    {
        // 0
        new List<string>()
        {
            "Mothman: Says something witty.",
            "Player: Reacts apropriately",
            "Mothman: Asks a question",
            "Player: @1 1.yes @2 2.no"
        },

        // 1
        new List<string>()
        {
            "Mothman: Says something witty.",
            "Player: Reacts apropriately",
            "Mothman: Asks a question",
            "Player: @1 1.yes @2 2.no"
        }
    };
}
