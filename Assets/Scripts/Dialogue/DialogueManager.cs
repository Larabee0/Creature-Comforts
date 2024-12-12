using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime; //needed to interact with ink

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkFile; //reference to inkfile
    public bool isTalking = false;

    static Story story; //story from inkfile
    Text nametag;
    Text message;
    List<string> tags;
    static Choice choiceSelected; //which choice was chosen

    private void Start()
    {
        story = new Story(inkFile.text); //load in story
        tags = new List<string>();
        choiceSelected = null; //no choice made yet
        message.text = "NOTASSIGNED"; //temporary name
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) //player hits next
        {
            //if more story
            if (story.canContinue)
            {
                message.text = AdvanceDialogue();

                //Are there any choices?
                if (story.currentChoices.Count != 0)
                {
                    //show choices to player
                }
            }

            //if no more story
            else
            {
                FinishDialogue();
            }
        }
    }

    /// <summary>
    /// Finished the Story (Dialogue)
    /// </summary>
    private void FinishDialogue()
    {
        Debug.Log("End of Dialogue!");
    }

    /// <summary>
    /// Advance through the story 
    /// </summary>
    string AdvanceDialogue()
    {
        string currentSentence = story.Continue();
        ParseTags();
        StopAllCoroutines();
        return currentSentence;
    }

    /// <summary>
    /// Tells the story which branch to go to
    /// </summary>
    /// <param name="element"></param>
    public static void SetDecision(object element)
    {
        choiceSelected = (Choice)element;
        story.ChooseChoiceIndex(choiceSelected.index);
    }

    /// <summary>
    /// read in tags
    /// </summary>
    void ParseTags()
    {
        tags = story.currentTags;
        foreach (string t in tags)
        {
            // do something
        }
    }
}

// if not working see:
// https://github.com/RisingArtist/Ink-with-Unity-2019.3/blob/master/Assets/DialogueManager.cs
// https://www.youtube.com/watch?v=-nK-tQ_vc0Y&t=420s