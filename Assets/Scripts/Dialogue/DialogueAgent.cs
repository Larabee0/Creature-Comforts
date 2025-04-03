using System;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class DialogueAgent : MonoBehaviour {
	public string npcTalking = "Mothman";

	TextScrollingScript tss;

	public bool pause;

	public TextAsset inkJSONAsset = null;
	public Story story;

	// UI Prefabs
	[SerializeField]
	List<Button> buttons = new List<Button>();

	[SerializeField]
	Image nameTag;
	[SerializeField]
	List<Sprite> nameTags = new List<Sprite>();

	public NPC_Expr npcExpr;
	[SerializeField]
	Image head, arms, body, hair;

	public GameState gs;
	public List<MoveAndFade> heartAnim = new List<MoveAndFade>();
	public List<MoveAndFade> brokenHeartAnim = new List<MoveAndFade>();

    private void Start()
    {
        tss = GetComponent<TextScrollingScript>();
    }

    private void Update()
    {
        if (story != null && story.currentChoices.Count == 0 && !pause && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetMouseButtonDown(0)))
		{
			RefreshView();
		}
    }

    // Creates a new Story object with the compiled story which we can then play!
    public void StartStory () {
		pause = false;
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
			gs.UpdateGamestate();
			gs.talking.enabled = false;
			pause = true;
			if (gs.currentGameState == "key1" || gs.currentGameState == "key2")
			{
				gs.ShowKeyHud();
			}
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
		if (!pause)
		{
			story.ChooseChoiceIndex (choice.index);
			RefreshView();
		}
	}

	// Creates a textbox showing the the line of text
	void CreateContentView (string text) {
		pause = true;
		tss.ScrollText("TEMP", text);
		if (story.currentTags.Count > 0)
		{
			ParseTags();
		}
		//Debug.Log(text + " : " + story.currentTags.Count);
	}

	void ParseTags ()
	{
		List<string> tags = new List<string>();

		tags = story.currentTags;
		foreach (string tag in tags)
		{
			string prefix = tag.Split(' ')[0].ToLower();

			switch (prefix)
			{
				case "s":
					string suffix = tag.Split(" ")[1].ToLower();
					if (suffix == "you")
						nameTag.sprite = nameTags[1];
					else if (suffix == "mothman")
						nameTag.sprite = nameTags[0];
					else if (suffix == "nessie")
						nameTag.sprite = nameTags[2];
					else if (suffix == "boss")
						nameTag.sprite = nameTags[3];
					break;

				case "plus":
					gs.ModifySentiment(npcTalking, int.Parse(tag.Split(" ")[1]));
					if (int.Parse(tag.Split(" ")[1]) > 0)
					{
						foreach (MoveAndFade i in heartAnim) 
						{
							i.StartAnim();
						}
					}
					break;

				case "minus":
                    gs.ModifySentiment(npcTalking, 0 - int.Parse(tag.Split(" ")[1]));
					foreach (MoveAndFade i in brokenHeartAnim)
					{
						i.StartAnim();
					}
                    break;

                case "h":
					head.sprite = npcExpr.GetHead(npcTalking ,int.Parse(tag.Split(" ")[1]));
					break;

				case "b":
                    body.sprite = npcExpr.GetBody(npcTalking, int.Parse(tag.Split(" ")[1]));
                    break;

				case "a":
                    arms.sprite = npcExpr.GetArms(npcTalking, int.Parse(tag.Split(" ")[1]));
                    break;

				case "p":
					hair.sprite = npcExpr.GetHair(npcTalking, int.Parse(tag.Split(" ")[1]));
					break;

				default:
					Debug.Log("tag err: " + tag);
					break;
			}
		}
	}
}