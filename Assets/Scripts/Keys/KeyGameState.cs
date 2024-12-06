using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyGameState : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();

    void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int x = i+1;
            buttons[i].onClick.AddListener(() => ButtonClicked(x));
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = x.ToString();
        }
    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log(buttonNo);
    }
}
