﻿using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class DialogueAgent : MonoBehaviour
{
	public string npcTalking = "Mothman";
	string text;

	TextScrollingScript tss;

	public bool pause;

	public TextAsset inkJSONAsset = null;
	public Story story;

	// UI Prefabs
	[SerializeField]
	List<Button> buttons = new();

	[SerializeField] List<Button> buttonsPhone = new();

	[SerializeField]
	Image nameTag;
	[SerializeField]Image nameTagPhone;
	[SerializeField]
	List<Sprite> nameTags = new();

	public NPC_Expr npcExpr;
	[SerializeField]
	Image head, arms, body, hair;

	public GameState gs;
	public List<MoveAndFade> heartAnim = new();
	public List<MoveAndFade> brokenHeartAnim = new();

	private bool storyStartedThisFrame = false;
	[SerializeField] private bool debugSkip = false;
	public UIAudio uIAudio, altUIAudio;
	public GameObject dialogueNav;

    // simplified access to buttons that skip diagloue
    private bool SkipTrigger => !storyStartedThisFrame && (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return) || Input.GetMouseButtonUp(0));

	private void Start()
	{
		tss = GetComponent<TextScrollingScript>();
	}

	private void Update()
	{

#if UNITY_EDITOR
		if (Input.GetKeyUp(KeyCode.F2))
		{
			debugSkip = true;
		}
#endif

		if (story != null && (SkipTrigger || debugSkip)) // guard agaist the story being null once
		{
			if (debugSkip && story.currentChoices.Count == 0)
            {
                tss.SkipLine(text);
            }
            else
            {
				debugSkip = false;
            }
			if (story.currentChoices.Count == 0 && !pause) //  try skip the whole block
			{
				RefreshView();
			}
			else // if skipping the whole block is not avaliable then try skip a single line??
			{
				tss.SkipLine(text);
			}
		}

		storyStartedThisFrame = false;
    }

	// Creates a new Story object with the compiled story which we can then play!
	public void StartStory()
	{
        dialogueNav.SetActive(false);
        pause = false;
		story = new Story(inkJSONAsset.text);
		RefreshView();
        storyStartedThisFrame = true;
        EventSystem.current.SetSelectedGameObject(null);

    }

	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView()
	{
		// Read all the content until we can't continue any more
		if (story.canContinue)
		{
			// Continue gets the next line of the story
			text = story.Continue();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen!
			CreateContentView(text);
            for (int i = 0; i < buttons.Count; i++)
			{
                Button button = buttons[i];
                button.GetComponent<Image>().enabled = false;
				button.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
				button = buttonsPhone[i];
                button.GetComponent<Image>().enabled = false;
                button.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
		}

		// If we've read all the content and there's no choices, the story is finished!
		else if (!story.canContinue)
		{
			gs.UpdateGamestate();
			gs.talking.enabled = false;
			gs.talkingPhone.enabled = false;
			pause = true;
			if (gs.currentGameState == "key1" || gs.currentGameState == "key2" || gs.currentGameState == "key3")
			{
				gs.ShowKeyHud();
            }

			if(gs.currentGameState == "report" || gs.currentGameState == "final_report")
			{
				gs.ShowBossReport();
			}

            dialogueNav.SetActive(true);
            story = null;
			return;
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
                buttonsPhone[i].GetComponent<Image>().enabled = true;
                buttonsPhone[i].GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                buttonsPhone[i].GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
                // Tell the button what to do when we press it
                buttonsPhone[i].onClick.AddListener(delegate
                {
                    OnClickChoiceButton(choice);
                });
            }
		}
	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton(Choice choice)
	{
		if (story == null) return;
		if (!pause && choice.index < story.currentChoices.Count)
		{

			story.ChooseChoiceIndex(choice.index);
			RefreshView();
			if (altUIAudio != null)
			{
				altUIAudio.PlayMenuButton();
			}
		}

		EventSystem.current.SetSelectedGameObject(null);
	}

	// Creates a textbox showing the the line of text
	void CreateContentView(string text)
	{
		pause = true;
		tss.ScrollText(text);
		if (story.currentTags.Count > 0)
		{
			ParseTags();
		}
	}

	void ParseTags()
	{
        List<string> tags = story.currentTags;
        foreach (string tag in tags)
		{
			string prefix = tag.Split(' ')[0].ToLower();

			switch (prefix)
			{
				case "s":
					string suffix = tag.Split(" ")[1].ToLower();
					if (suffix == "you")
					{
                        nameTagPhone.sprite = nameTag.sprite = nameTags[1];

					}
					else if (suffix == "mothman")
					{
                        nameTagPhone.sprite = nameTag.sprite = nameTags[0];
                    }
					else if (suffix == "nessie")
					{
                        nameTagPhone.sprite = nameTag.sprite = nameTags[2];
                    }
					else if (suffix == "boss")
					{
                        nameTagPhone.sprite = nameTag.sprite = nameTags[3];
                    }
					else if (suffix == "publisher")
                    {
                        nameTagPhone.sprite = nameTag.sprite = nameTags[5];
                    }
						break;

				case "plus":
					gs.ModifySentiment(npcTalking, int.Parse(tag.Split(" ")[1]));
					if (int.Parse(tag.Split(" ")[1]) > 0)
					{
						if (uIAudio != null)
						{
							uIAudio.PlayCorrectChoice();
						}
						foreach (MoveAndFade i in heartAnim) 
						{
							i.StartAnim();
						}
					}
					break;

				case "minus":
                    gs.ModifySentiment(npcTalking, 0 - int.Parse(tag.Split(" ")[1]));

                    if (uIAudio != null)
                    {
                        uIAudio.PlayIncorrectChoice();
                    }
                    foreach (MoveAndFade i in brokenHeartAnim)
					{
						i.StartAnim();
					}
					break;

				case "h":
					head.sprite = npcExpr.GetHead(npcTalking, int.Parse(tag.Split(" ")[1]));
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
					Debug.LogErrorFormat("Invalid tag: {0} Story: {1}", tag,story.path.ToString());
					break;
			}
		}
	}
}