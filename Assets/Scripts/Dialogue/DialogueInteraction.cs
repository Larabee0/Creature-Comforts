using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DialogueInteraction : MonoBehaviour
{
    public TextScrollingScript ts;

    string[,] DVal = { { "Mothman", "Greeting" }, { "Mothman", "RomanceLVL1" }, { "Nessie", "RomanceLVL1" } };


    int pos = 0;

    private void Start()
    {
        ts.ScrollText(DVal[pos,0] + ": ", DEPRICATED_CharacterSript.CHARACTERS[DVal[pos,0]][DVal[pos,1]]);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            incrementpos();
        }
    }

    void incrementpos()
    {
        pos++;
        ts.ScrollText(DVal[pos, 0] + ": ", DEPRICATED_CharacterSript.CHARACTERS[DVal[pos, 0]][DVal[pos, 1]]);
    }
}
