using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextScrollingScript : MonoBehaviour
{
    public DialogueAgent agent;

    public TextMeshProUGUI tmp;
    public TextMeshProUGUI speaker;
    string buildUpString = "";

    public Image endMarker;

    private void Start()
    {
        agent = GetComponent<DialogueAgent>();
    }

    public void ScrollText(string name = "NO_NAME_GIVEN", string inputText = "NO_TEXT_GIVEN")
    { 
        endMarker.enabled = false; //turns off endmarker at the start of line scroll

        List<string> constructionParts = new List<string>(); // list to hold all the parts of the line
        string stringPart = ""; // this stores the part of the string that is being constructed
        for (int i = 0; i < inputText.Length; i++) // for each character in the line
        {
            if (inputText[i] == '<' && i > 0) // if the current character is the start of a MD tag and not the first character
            {
                constructionParts.Add(stringPart); // add what you have made to construction parts
                stringPart = ""; // reset string part
                stringPart += inputText[i]; // add this character to string part
            }
            else if (inputText[i] == '>') // if the current character is the end of a MD tag
            {
                stringPart += inputText[i]; // add the current character to string part
                constructionParts.Add(stringPart); // add that you have made to construction parts
                stringPart = ""; // reset string part
                if (i == inputText.Length - 1)
                    break;
            }
            else // if current characte is not the start or end of a MD tag
            {
                stringPart += inputText[i]; // add current character to string part
            }
            if (i == inputText.Length - 1) // if you have reached the end of the line
            {
                constructionParts.Add(stringPart); // add what you have made to construction parts
            }
        }

        // speaker.text = name; // DEPRICATED
        buildUpString = ""; // creates a place to store text as it is made
        int strLen = inputText.Length; // find out length of line so that inputs can be unpaused
        int placeKeeper = 0; // create a value to keep the place in line
        for (int i = 0; i < constructionParts.Count; i++) // for each chunk of dialogue and MD tag
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
        endMarker.enabled = true;
        agent.pause = false;
    }
}
