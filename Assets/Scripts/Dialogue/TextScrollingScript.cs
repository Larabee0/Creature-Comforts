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
        List<string> constructionParts = new List<string>();
        string stringPart = "";
        for (int i = 0; i < inputText.Length; i++)
        {
            if (inputText[i] == '<')
            {
                constructionParts.Add(stringPart);
                stringPart = "";
                stringPart += inputText[i];
            }
            else if (inputText[i] == '>')
            {
                stringPart += inputText[i];
                constructionParts.Add(stringPart);
                stringPart = "";
            }
            else
            {
                stringPart += inputText[i]; 
            }
            if (i == inputText.Length - 1)
            {
                constructionParts.Add(stringPart);
            }
        }

        speaker.text = name;
        buildUpString = "";
        int strLen = inputText.Length;
        int placeKeeper = 0;
        for (int i = 0; i < constructionParts.Count; i++)
        {
            if (constructionParts[i][0] == '<')
            {
                StartCoroutine(PrintInOrder(placeKeeper, constructionParts[i]));
            }
            else
            {
                for (int j = 0; j < constructionParts[i].Length; j++)
                {
                    StartCoroutine(PrintInOrder(placeKeeper + j, ""+constructionParts[i][j]));
                }
            }
            placeKeeper += constructionParts[i].Length;
        }
        StartCoroutine(UnpauseInputs(strLen));
    }

    IEnumerator PrintInOrder(int i, string s)
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
