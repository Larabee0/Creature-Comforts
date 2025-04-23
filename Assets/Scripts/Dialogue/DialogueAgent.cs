using System.Collections;
using System.Collections.Generic;
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

	[SerializeField]
	Image nameTag;
	[SerializeField]
	List<Sprite> nameTags = new();

	public NPC_Expr npcExpr;
	[SerializeField]
	Image head, arms, body, hair;

	public GameState gs;
	public List<MoveAndFade> heartAnim = new();
	public List<MoveAndFade> brokenHeartAnim = new();

	[SerializeField] private float doubleTapTimeout = 0.5f;
	private bool doubleTapGuard;
	private Coroutine timeout;
	private bool storyStartedThisFrame = false;
	public UIAudio uIAudio, altUIAudio;

	// simplified access to buttons that skip diagloue
	private bool SkipTrigger => !storyStartedThisFrame && (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return) || Input.GetMouseButtonUp(0));

	private void Start()
	{
		tss = GetComponent<TextScrollingScript>();
	}

	private void Update()
	{
		if (story != null && SkipTrigger) // guard agaist the story being null once
		{
			if (doubleTapGuard) // on second click
			{
				if (story.currentChoices.Count == 0 && !pause) //  try skip the whole block
				{
					RefreshView();
				}
				else // if skipping the whole block is not avaliable then try skip a single line??
				{
					tss.SkipLine(text);
				}
				StopDoubleTapTimeout(); // consume double click
			}
			else // skip a single line of diagloue
            {
                if (story.currentChoices.Count == 0 && !pause) //  try skip the whole block
                {
                    RefreshView();
                }
                else // if skipping the whole block is not avaliable then try skip a single line??
                {
                    tss.SkipLine(text);
                }

                StopDoubleTapTimeout(); // reset incase the corotuine is till running
				StartCoroutine(DoubleTapTimeout()); // set double click flag and start timeout for it.
			}
		}
		storyStartedThisFrame = false;

    }

	// manual way to end the double tap time out early
	// this is used in case of a second button press to consume that double tap
	// meaning the next button repss will skip a line instead of the whole page.
	private void StopDoubleTapTimeout()
	{
		doubleTapGuard = false;
		if (timeout != null)
		{
			StopCoroutine(timeout);
			timeout = null;
		}
	}

	// simple double press system, after first press, seet this flag to true
	// after the duration passes set it to false and the coroutine to null
	private IEnumerator DoubleTapTimeout()
	{
		doubleTapGuard = true;
		yield return new WaitForSeconds(doubleTapTimeout);
		doubleTapGuard = false;
		timeout = null;

	}

	// Creates a new Story object with the compiled story which we can then play!
	public void StartStory()
	{
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
			altUIAudio.PlayMenuButton();
		}
		else if (choice.index >= story.currentChoices.Count)
		{
			Debug.LogWarningFormat(gameObject, "Choice index out of range {0} Target: {1}, Source: {0}", choice.index, choice.targetPath, choice.sourcePath);
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
		//Debug.Log(text + " : " + story.currentTags.Count);
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
						uIAudio.PlayCorrectChoice();
						foreach (MoveAndFade i in heartAnim) 
						{
							i.StartAnim();
						}
					}
					break;

				case "minus":
                    gs.ModifySentiment(npcTalking, 0 - int.Parse(tag.Split(" ")[1]));
					uIAudio.PlayIncorrectChoice();
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
					Debug.Log("tag err: " + tag);
					break;
			}
		}
	}
}