using System;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class DialogueAgent : MonoBehaviour {

	TextScrollingScript tss;

	public TextAsset inkJSONAsset = null;
	public Story story;

	// UI Prefabs
	[SerializeField]
	List<Button> buttons = new List<Button>();

    private void Start()
    {
        tss = GetComponent<TextScrollingScript>();
    }

    private void Update()
    {
        if (story.currentChoices.Count == 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)))
		{
			RefreshView();
		}
    }

    // Creates a new Story object with the compiled story which we can then play!
    public void StartStory () {
		story = new Story (inkJSONAsset.text);
		RefreshView();
	}
	
	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView () {

		// Read all the content until we can't continue any more
		if (story.canContinue)
		{
			// Continue gets the next line of the story
			string text = story.Continue();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen!
			CreateContentView(text);
			foreach (Button button in buttons)
			{
				button.GetComponent<Image>().enabled = false;
				button.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
			}
		}
		
		// If we've read all the content and there's no choices, the story is finished!
		else if (!story.canContinue)
		{
			StartStory();
		}

		// Display all the choices, if there are any!
		if (story.currentChoices.Count > 0)
		{
			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				Choice choice = story.currentChoices[i];
				buttons[i].GetComponent<Image>().enabled = true;
				buttons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
				buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
				// Tell the button what to do when we press it
				buttons[i].onClick.AddListener(delegate
				{
					OnClickChoiceButton(choice);
				});
			}
		}
	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	// Creates a textbox showing the the line of text
	void CreateContentView (string text) {
		Debug.Log (text);
		tss.ScrollText("TEMP", text);
	}
}