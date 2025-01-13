using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScrollingScript : MonoBehaviour
{ 
    public DialogueInteractor interactor;

    public TextMeshProUGUI tmp;
    public TextMeshProUGUI speaker;
    string buildUpString = "";

    public void ScrollText(string name = "NO_NAME_GIVEN", string inputText = "NO_TEXT_GIVEN")
    { 
        speaker.text = name;
        buildUpString = "";
        int strLen = inputText.Length;
        for (int i = 0; i < strLen; i++)
        {
            StartCoroutine(PrintInOrder(i, inputText[i]));
        }
        StartCoroutine(UnpauseInputs(strLen));
    }

    IEnumerator PrintInOrder(int i, char s)
    {
        yield return new WaitForSeconds(i / (SettingsScript.textScrollSpeed * 10));
        buildUpString += s;
        tmp.text = buildUpString;
    }

    IEnumerator UnpauseInputs(int i)
    {
        yield return new WaitForSeconds(i / (SettingsScript.textScrollSpeed * 10));
        interactor.pause = false;
    }
}
