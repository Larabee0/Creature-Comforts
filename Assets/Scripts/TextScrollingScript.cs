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

    string buildUpString = "";

    void Start()
    {
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
