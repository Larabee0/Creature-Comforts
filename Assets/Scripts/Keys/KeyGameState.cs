using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyGameState : MonoBehaviour
{
    public GameObject heldKey;
    bool holdingKey = false;
    int heldKeyVal;

    public AudioSFX sfx;
    public Image bellIcon;

    public Image winImg;

    public bool won = false;
    public bool gameRunning = false;
    float clock = 0f;
    public Image timer;

    public GameState gs;

    KeyData data;
    int[] localBoard; //refrence to the board layout

    public List<GameObject> buttons = new List<GameObject>(); //refrence to the buttons

    void Start()
    {
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
    }

    private void Update()
    {
        //StartKeyGame();

        if (gameRunning)
        {
            clock += Time.deltaTime;
            timer.GetComponentInChildren<TextMeshProUGUI>().text = (int)clock + "." + ((int)(clock * 10) - (int)clock*10) + "s";
        }
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
                    thistmp.text = "" + heldKeyVal;
                    won = data.CheckForSuccess();
                    if (won)
                    {
                        WinScreen();
                        if (gs.grade1 == 0)
                        {
                            if (clock < 13)
                                gs.grade1 = '4';
                            else if (clock < 17)
                                gs.grade1 = 3;
                            else if (clock < 20)
                                gs.grade1 = 2;
                            else
                                gs.grade1 = 1;
                        }
                        else
                        {
                            if (clock < 27)
                                gs.grade2 = 4;
                            else if (clock < 31)
                                gs.grade2 = 3;
                            else if (clock < 36)
                                gs.grade2 = 2;
                            else
                                gs.grade2 = 1;
                        }
                        gs.UpdateGamestate();
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
                    heldKey.GetComponentInChildren<TextMeshProUGUI>().text = valAtLoc.ToString();
                    heldKey.GetComponentInChildren<TextMeshProUGUI>().raycastTarget = false;
                    Image thisKey = buttons[buttonNo - 1].GetComponentInChildren<KeyLoc>().GetComponent<Image>();
                    TextMeshProUGUI thistmp = thisKey.GetComponentInChildren<TextMeshProUGUI>();
                    thisKey.enabled = false;
                    thistmp.enabled = false;
                }
            }
        }
    }

    public void StartKeyGame(int difficulty = 1)
    {
        if (!gameRunning) 
        {
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
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = data.GetHookValAtLocation(x).ToString();
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
                thistmp.text = "" + kvp.Key;
                Debug.Log("" + kvp.Key);
            }
        }
    }

    void WinScreen()
    {
        winImg.enabled = true;
        gameRunning = false;
        Debug.Log("winscrn");
        //sfx.Bell();
        //bellIcon.enabled = true;
    }
}