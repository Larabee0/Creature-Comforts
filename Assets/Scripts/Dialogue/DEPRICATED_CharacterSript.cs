using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DEPRICATED_CharacterSript
{
    public static Dictionary<string, Dictionary<string, string>> CHARACTERS = new Dictionary<string, Dictionary<string, string>>()
    {
        { "Mothman",
            new Dictionary<string, string> {
                { "Greeting", "Hello" }, 
                { "Leaving", "Goodbye" },
                { "RomanceLVL1", "Lamp...?" } }
        },
        { "Nessie",
            new Dictionary<string, string>
            {
                { "Greeting", "top o' the morning" },
                { "Leaving", "cya" },
                { "RomanceLVL1", "Nessie used splash...but nothing happened" }
            }
        },
        { "Bigfoot", 
            new Dictionary<string, string>
            {
                { "Greeting", "Hey their neighbour" },
                { "Leaving", "Bigfoot out!" },
                { "RomanceLVL1", "Lemme at them trees" }
            }
        }
    };
}
