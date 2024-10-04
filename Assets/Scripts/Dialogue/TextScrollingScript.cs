using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScrollingScript : MonoBehaviour
{ 
    float letterClock = 0f;
    int pos = 0;

    public TextMeshProUGUI tmp;
    string buildUpString = "";

    public void ScrollText(string name = "NO_NAME_GIVEN", string inputText = "NO_TEXT_GIVEN")
    { 
        buildUpString = name;
        for (int i = 0; i < inputText.Length; i++)
        {
            StartCoroutine(PrintInOrder(i, inputText[i]));
        }
    }

    IEnumerator PrintInOrder(int i, char s)
    {
        yield return new WaitForSeconds(i / (SettingsScript.textScrollSpeed * 10));
        buildUpString += s;
        tmp.text = buildUpString;
    }
}
