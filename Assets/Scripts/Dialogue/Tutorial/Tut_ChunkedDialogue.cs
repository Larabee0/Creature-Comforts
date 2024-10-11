using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class Tut_ChunkedDialogue
{
    public static List<List<string>> dialogue = new List<List<string>>()
    {
        // 0
        new List<string>()
        {
            "Narrator: The phone on your desk is ringing. It’s probably your boss.",
            "Boss: Oh good, you picked up.",
            "Boss: Welcome back to work, it’s almost like you never left.",
            "Boss: Ok, here’s the sitch: It’s opening day for our autumn season and I need you to be on FULL alert.",
            "Boss: Plenty of customers will be checking in today and I can’t have you slacking.",
            "Boss: The usual admin will be waiting for you on our Motel Systems, just look at the computer behind you.",
            "Tutorial: Press DOWN ARROW to switch to the computer screen."
        },

        // 1
        new List<string>()
        {
            "Boss: It’s been a while, I suppose I’ll have to run you through it. This is the reception desk computer.",
            "Boss: Before you ask, yes it still takes floppy disks. Not like you’ll be needing to use that feature though.",
            "Boss: Anyways, this monitor will act as your personal database for everything [MOTEL NAME] related.",
            "Boss: I’ll be sending you EMAILS with your tasks for each day. Make sure to complete them all or I won’t let you go home.",
            "Boss: Haha! Just kidding (not)."
        }
    };
}
