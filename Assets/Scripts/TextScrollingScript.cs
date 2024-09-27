using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScrollingScript : MonoBehaviour
{
    string inputText = "This is a text scrolling test. The text should be scrolling naturally. Test. Test. Test. Test. Test. Test. Test. Test.";

    float letterClock = 0f;
    int pos = 0;

    public TextMeshProUGUI tmp;
    public float scrollSpeed = 0.04f;

    string buildUpString = "";

    void Start()
    {
        inputText = CharacterSript.CHARACTERS["Nessie"]["RomanceLVL1"];
        for (int i = 0; i < inputText.Length; i++)
        {
            StartCoroutine(PrintInOrder(i, inputText[i]));
        }
    }

    IEnumerator PrintInOrder(int i, char s)
    {
        yield return new WaitForSeconds(scrollSpeed * i);
        buildUpString += s;
        tmp.text = buildUpString;
    }
}
