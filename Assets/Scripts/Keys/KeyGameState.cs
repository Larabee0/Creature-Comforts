using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyGameState : MonoBehaviour
{
    KeyData data;
    int[] localBoard; //refrence to the board layout

    public List<GameObject> buttons = new List<GameObject>(); //refrence to the buttons

    void Start()
    {
        data = GetComponent<KeyData>(); //gets instance of keydata

        data.GenerateBoard(); //randomise the board
        localBoard = data.boardVals; //update board to reflect new randomness

        //for each button call ButtonClicked function while passing corresponding val
        for (int i = 0; i < buttons.Count; i++)
        {
            int x = i+1;
            buttons[i].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(x));
        }
        //for debugging
        for (int i = 0; i < buttons.Count; i++)
        {
            int x = localBoard[i];
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = x.ToString();
        }
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log(buttonNo);

        //temp
        if (data.GetBoardValAtLocation(buttonNo) == 15)
        {
            Image img = buttons[buttonNo - 1].GetComponentInChildren<KeyLoc>().GetComponent<Image>();
            img.color = Color.white;
        }
        else
        {
            Debug.Log(data.GetBoardValAtLocation(buttonNo));
        }
    }
}
