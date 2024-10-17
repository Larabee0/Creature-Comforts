using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using TreeEditor;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.Timeline;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using UnityEngine.XR;
using static UnityEditor.UIElements.ToolbarMenu;
using static UnityEngine.ProBuilder.AutoUnwrapSettings;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

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
            "You: That’s why we are called Foggy Lake.",
            "Mothman: Hmm, how pleasant.",
            "Mothman: Anyway I came here for the reception and you are that, yes?",
            "Narrator: The customer gives you no time to give a response before launching into a request.",
            "Mothman: I’m checking in, room 15. You’ll be taking my bags upstairs.",
            "Narrator: They mutter something inaudibly under their breath, but you just about catch it.",
            "Mothman: Honestly would have thought my agent could pick a better sort of establishment than this… this… place.",
            "You: Remain awkwardly silent.",
            "Mothman: I’m on a business trip so will be quite vacant this week, regardless I expect timely service.",
            "Narrator: They leave a check in slip behind. The details read: Mothman. Author. Business Trip (how about none of YOUR business).",
            "You: How vague… You return to your desk work, albeit slightly perplexed."
        },

        // 1
        new List<string>()
        {
            "Nessie: Hi, hello sorry I’m late, I got stuck behind a fallen tree in the river system and I had to swim around it and-",
            "Narrator: The new guest appears frazzled and upset.",
            "You: Reassure them",
            "Narrator: You smile in a friendly manner and they seem to calm down.",
            "Nessie: I’m SO sorry. Let me just fetch my information…It’ll only be a minute!",
            "Nessie: Here you go!!! I hope it’s still alright I got here late.",
            "Narrator: You nod along and process their paperwork.",
            "Nessie: Thank you so so much, I’m here to research something really important...", 
            "Nessie: and I’d hate to waste that opportunity because of a silly delay.",
            "Nessie: Maybe I’ll tell you about it next time… I’ll see you around, ok? Thanks again!",
            "Narrator: After they run into the distance with a bundle of bags you take a glance at their paperwork. Loch Ness Monster (Nessie). ",
            "Narrator: Scientist/Researcher/Curious Person or whatever you want to call it :) Here to look at plants!!! Room 82.",
            "You: Return to work, a little more tired than before."
        }
    };
}
