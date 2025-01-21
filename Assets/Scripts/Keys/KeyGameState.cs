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

    KeyData data;
    int[] localBoard; //refrence to the board layout

    public List<GameObject> buttons = new List<GameObject>(); //refrence to the buttons

    void Start()
    {
        data = GetComponent<KeyData>(); //gets instance of keydata

        data.GenerateBoard(); //randomise the board
        localBoard = data.boardVals; //update board to reflect new randomness

        heldKey.GetComponent<Image>().enabled = false;
        heldKey.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log(buttonNo);

        int valAtLoc = data.GetKeyValAtBoardLocation(buttonNo);

        if (!won)
        {
            if (holdingKey)
            {
                if (valAtLoc == 0)
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
                    Image thisKey = buttons[buttonNo - 1].GetComponentInChildren<KeyLoc>().GetComponent<Image>();
                    TextMeshProUGUI thistmp = thisKey.GetComponentInChildren<TextMeshProUGUI>();
                    thisKey.enabled = false;
                    thistmp.enabled = false;
                }
            }
        }
    }

    public void StartKeyGame()
    {
        //for each button call ButtonClicked function while passing corresponding val
        for (int i = 0; i < buttons.Count; i++)
        {
            int x = i + 1;
            buttons[i].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(x));
        }
        for (int i = 0; i < buttons.Count; i++)
        {
            int x = i + 1;
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = data.GetHookValAtLocation(x).ToString();
        }

        foreach (KeyValuePair<int, int> kvp in data.keyToLocationPairs)
        {
            Image thisKey = buttons[kvp.Value - 1].GetComponentInChildren<KeyLoc>().GetComponent<Image>();
            TextMeshProUGUI thistmp = thisKey.GetComponentInChildren<TextMeshProUGUI>();
            thisKey.enabled = true;
            thistmp.enabled = true;
            thistmp.text = "" + kvp.Key;
        }
    }

    void WinScreen()
    {
        //winImg.enabled = true;
        sfx.Bell();
        //bellIcon.enabled = true;
    }
}