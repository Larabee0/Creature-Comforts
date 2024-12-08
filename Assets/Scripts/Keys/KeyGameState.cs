using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyGameState : MonoBehaviour
{
    KeyData data;
    int[] localBoard;

    public List<GameObject> buttons = new List<GameObject>();

    void Start()
    {
        data = GetComponent<KeyData>();

        data.GenerateBoard();
        localBoard = data.boardVals;

        for (int i = 0; i < buttons.Count; i++)
        {
            int x = i+1;
            buttons[i].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(x));
        }
        for (int i = 0; i < buttons.Count; i++)
        {
            int x = localBoard[i];
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = x.ToString();
        }
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log(buttonNo);

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
