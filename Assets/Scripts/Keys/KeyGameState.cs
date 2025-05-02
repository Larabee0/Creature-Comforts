using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyGameState : MonoBehaviour
{
    public KeyGameAudio kGAudio;
    public UIAudio uIAudio;

    public GameObject heldKey;
    bool holdingKey = false;
    int heldKeyVal;

    public Image bellIcon;

    public Image winImg;

    public bool won = false;
    public bool gameRunning = false;
    float clock = 0f;
    public Image timer;

    public GameState gs;

    public Button playButton;
    public Button keyNavRight;

    KeyData data;
    int[] localBoard; //refrence to the board layout

    public List<GameObject> buttons = new(); //refrence to the buttons

    void Start()
    {
        playButton.onClick.AddListener(PlayButtonClicked);
        playButton.GetComponentInChildren<TextMeshProUGUI>().raycastTarget = false;
        HidePlayButton();

        heldKey.GetComponent<Image>().enabled = false;
        heldKey.GetComponentInChildren<TextMeshProUGUI>().enabled = false;

        data = GetComponent<KeyData>(); //gets instance of keydata
        timer.enabled = false;
        timer.GetComponentInChildren<TextMeshProUGUI>().enabled = false;

        //for each button call ButtonClicked function while passing corresponding val
        for (int i = 0; i < buttons.Count; i++)
        {
            int x = i + 1;
            buttons[i].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(x));
        }

        data.GenerateBoard(); //randomise the board
        localBoard = data.boardVals; //update board to reflect new randomness
        for (int i = 0; i < buttons.Count; i++)
        {
            int x = i + 1;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = GetKeyText(data.GetHookValAtLocation(x));
        }
    }

    private void Update()
    {
        //StartKeyGame();

        if (gameRunning)
        {
            clock += Time.deltaTime;
            timer.GetComponentInChildren<TextMeshProUGUI>().text = (int)clock + "." + ((int)(clock * 10) - (int)clock*10) + "s";
        }

#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.F1))
        {
            WinScreen();
        }
#endif
        }



    private string GetKeyText(int heldVal)
    {
        if(heldVal == 6 ||  heldVal == 9)
        {
            return string.Format("{0}.", heldVal);
        }
        return heldVal.ToString();
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log(buttonNo);

        int valAtLoc = data.GetKeyValAtBoardLocation(buttonNo);

        if (!won)
        {
            if (holdingKey)
            {
                if (valAtLoc == 0 || valAtLoc == heldKeyVal)
                {
                    holdingKey = false;
                    heldKey.GetComponent<Image>().enabled = false;
                    heldKey.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
                    data.PlaceKey(heldKeyVal, buttonNo);
                    Debug.Log(data.CheckForSuccess());
                    Image thisKey = buttons[buttonNo - 1].GetComponentInChildren<KeyLoc>().GetComponent<Image>();
                    TextMeshProUGUI thistmp = thisKey.GetComponentInChildren<TextMeshProUGUI>();
                    thisKey.enabled = true;
                    thistmp.enabled = true;
                    thistmp.text = GetKeyText(heldKeyVal);
                    won = data.CheckForSuccess();

                    if (kGAudio != null)
                    {
                        kGAudio.PlayPlace();
                    }
                    if (won)
                    {
                        WinScreen();
                    }
                }
            }

            else if (!holdingKey)
            {
                if (valAtLoc != 0)
                {
                    holdingKey = true;
                    heldKey.GetComponent<Image>().enabled = true;
                    heldKey.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                    heldKeyVal = valAtLoc;
                    heldKey.GetComponentInChildren<TextMeshProUGUI>().text = GetKeyText(valAtLoc);
                    heldKey.GetComponentInChildren<TextMeshProUGUI>().raycastTarget = false;
                    Image thisKey = buttons[buttonNo - 1].GetComponentInChildren<KeyLoc>().GetComponent<Image>();
                    TextMeshProUGUI thistmp = thisKey.GetComponentInChildren<TextMeshProUGUI>();
                    thisKey.enabled = false;
                    thistmp.enabled = false;
                    if (kGAudio != null)
                    {
                        kGAudio.PlayPickup();
                    }
                }
            }
        }
    }

    public void StartKeyGame(int difficulty = 1)
    {
        if (gameRunning)
        {
            return;
        }

        gs.HideKeyHud();

        timer.enabled = true;
        timer.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        clock = 0;
        gameRunning = true;
        won = false;
        winImg.enabled = false;

        data.keyToLocationPairs = new Dictionary<int, int>();
        data.locationToHookPairs = new Dictionary<int, int>();

        data.GenerateBoard(); //randomise the board
        localBoard = data.boardVals; //update board to reflect new randomness
        data.GenerateKeys(difficulty);

        heldKey.GetComponent<Image>().enabled = false; //hide the key in hand
        heldKey.GetComponentInChildren<TextMeshProUGUI>().enabled = false;

        for (int i = 0; i < buttons.Count; i++)
        {
            int x = i + 1;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = GetKeyText(data.GetHookValAtLocation(x)).ToString();
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            Image thisKey = buttons[i].GetComponentInChildren<KeyLoc>().GetComponent<Image>();
            TextMeshProUGUI thistmp = thisKey.GetComponentInChildren<TextMeshProUGUI>();
            thisKey.enabled = false;
            thistmp.enabled = false;
        }

        foreach (KeyValuePair<int, int> kvp in data.keyToLocationPairs)
        {
            Image thisKey = buttons[kvp.Value - 1].GetComponentInChildren<KeyLoc>().GetComponent<Image>();
            TextMeshProUGUI thistmp = thisKey.GetComponentInChildren<TextMeshProUGUI>();
            thisKey.enabled = true;
            thistmp.enabled = true;
            thistmp.text = GetKeyText(kvp.Key);
            Debug.Log("" + kvp.Key);
        }
    }

    void WinScreen()
    {
        uIAudio.PlayCorrectChoice();
        winImg.enabled = true;

        keyNavRight.gameObject.SetActive(true);
        gameRunning = false;
        Debug.Log("winscrn");
        if (gs.currentGameState == "key1")
        {
            if (clock < 13)
                gs.gradeList.Add(4);
            else if (clock < 17)
                gs.gradeList.Add(3);
            else if (clock < 20)
                gs.gradeList.Add(2);
            else
                gs.gradeList.Add(1);
        }
        else if (gs.currentGameState == "key2")
        {
            if (clock < 27)
                gs.gradeList.Add(4);
            else if (clock < 31)
                gs.gradeList.Add(3);
            else if (clock < 36)
                gs.gradeList.Add(2);
            else
                gs.gradeList.Add(1);
        }
        gs.UpdateGamestate();
        if (gs.currentGameState == "m_d1_s1" || gs.currentGameState == "m_d1_s2"
            || gs.currentGameState == "n_d1_s1" || gs.currentGameState == "n_d1_s2"
            || gs.currentGameState == "m_d2_s1" || gs.currentGameState == "m_d2_s2"
            || gs.currentGameState == "n_d2_s1" || gs.currentGameState == "n_d2_s2"
            || gs.currentGameState == "m_d3_s1" || gs.currentGameState == "n_d3_s1")
        {
            gs.ShowDialogueHud();
        }

    }

    void PlayButtonClicked()
    {
        if (gs.currentGameState == "key1")
            StartKeyGame(5);
        else if (gs.currentGameState == "key2")
            StartKeyGame(10);
        else if (gs.currentGameState == "key3")
            StartKeyGame(15);

        HidePlayButton();
    }

    public void HidePlayButton()
    {
        playButton.enabled = false;
        playButton.GetComponent<Image>().enabled = false;
        playButton.GetComponent<Image>().raycastTarget = false;
        playButton.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
    }

    public void ShowPlayButton()
    {
        winImg.enabled = false;
        playButton.enabled = true;
        playButton.GetComponent<Image>().enabled = true;
        playButton.GetComponent<Image>().raycastTarget = true;
        playButton.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
    }
}