using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextScrollingScript : MonoBehaviour
{
    public DialogueAgent agent;

    public TextMeshProUGUI tmp;

    private StringBuilder buildUpString = new();

    private Coroutine scrollCoroutine;

    public Image endMarker;

    int lineKey = 0;

    private void Start()
    {
        agent = GetComponent<DialogueAgent>();
    }

    public void SkipLine(string inputText)
    {
        lineKey++;
        tmp.text = inputText;
        agent.pause = false;
        endMarker.enabled = true;
        if (scrollCoroutine != null)
        {
            StopCoroutine(scrollCoroutine);
            scrollCoroutine = null;
        }
    }

    public void ScrollText(string inputText = "NO_TEXT_GIVEN")
    {
        endMarker.enabled = false; //turns off endmarker at the start of line scroll
        lineKey++;
        // get parts
        List<string> constructionParts = GenerateParts(inputText);

        if (scrollCoroutine != null)
        {
            StopCoroutine(scrollCoroutine);
        }
        scrollCoroutine = StartCoroutine(ScrollTextCoroutine(constructionParts));
    }

    private IEnumerator PrintSection(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            buildUpString.Append(str[i]);
            tmp.text = buildUpString.ToString();
            yield return new WaitForSeconds(1 / (SettingsScript.textScrollSpeed * 10));
        }
    }

    // instead of starting a coroutine for each letter and timing it all beatifully, I thought it'd be simpler to just do it as a big coroutine
    private IEnumerator ScrollTextCoroutine(List<string> constructionParts)
    {
        buildUpString = new(); // creates a place to store text as it is made
        for (int i = 0; i < constructionParts.Count; i++) // for each chunk of dialogue and MD tag
        {
            if (constructionParts[i].StartsWith('<'))
            {
                buildUpString.Append(constructionParts[i]);
                tmp.text = buildUpString.ToString();
            }
            else
            {
                yield return PrintSection(constructionParts[i]);
            }
        }
        yield return new WaitForSeconds(1 / (SettingsScript.textScrollSpeed * 10));
        endMarker.enabled = true;
        agent.pause = false;
        scrollCoroutine = null;
    }

    /// <summary>
    /// Generates a list of all parts of the line to display
    /// </summary>
    /// <param name="inputText"></param>
    /// <returns></returns>
    private static List<string> GenerateParts(string inputText)
    {
        List<string> constructionParts = new(); // list to hold all the parts of the line
        StringBuilder stringPart = new(); // this stores the part of the string that is being constructed
        for (int i = 0; i < inputText.Length; i++) // for each character in the line
        {
            if (inputText[i] == '<' && i > 0) // if the current character is the start of a MD tag and not the first character
            {
                constructionParts.Add(stringPart.ToString()); // add what you have made to construction parts
                stringPart = new(); // reset string part
                stringPart.Append(inputText[i]); // add this character to string part
            }
            else if (inputText[i] == '>') // if the current character is the end of a MD tag
            {
                stringPart.Append(inputText[i]); // add the current character to string part
                constructionParts.Add(stringPart.ToString()); // add that you have made to construction parts
                stringPart = new(); // reset string part
                if (i == inputText.Length - 1)
                    break;
            }
            else // if current characte is not the start or end of a MD tag
            {
                stringPart.Append(inputText[i]); // add current character to string part
            }

            if (i == inputText.Length - 1) // if you have reached the end of the line
            {
                constructionParts.Add(stringPart.ToString()); // add what you have made to construction parts
            }
        }

        return constructionParts;
    }
}
