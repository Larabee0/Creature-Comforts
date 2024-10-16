using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Timers;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using UnityEngine.XR;
using static UnityEditor.UIElements.ToolbarMenu;
using static UnityEngine.ProBuilder.AutoUnwrapSettings;

public static class ChunkedDialogue
{
    public static List<List<string>> dialogue = new List<List<string>>()
    {
        // 0
        new List<string>()
        {
            "Mothman: Aren’t you going to get that?",
            "Narrator: You better answer that bell.",
            "Mothman: Greetings, afternoon, or whatever time of day it's supposed to be.", 
            "Mothman: The fog outside does seem to ruin any sense of time, doesn’t it? ",
            "You: 1. That’s why we are called Foggy Lake.",
            "Mothman: Hmm, how pleasant.",
            "Mothman: Anyway I came here for the reception and you are that, yes?",
            "Narrator: The customer gives you no time to give a response before launching into a request.",
            "Mothman: I’m checking in, room 15. You’ll be taking my bags upstairs.",
            "Narrator: They mutter something inaudibly under their breath, but you just about catch it.",
            "Mothman: Honestly would have thought my agent could pick a better sort of establishment than this… this… place.",
            "You: 1. Remain awkwardly silent.",
            "Mothman: I’m on a business trip so will be quite vacant this week, regardless I expect timely service.",
            "Narrator: They leave a check in slip behind. The details read: Mothman. Author. Business Trip (how about none of YOUR business).",
            "You: 1. How vague… You return to your desk work, albeit slightly perplexed."
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
