using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    int tracker = 0;
    
    public string currentGameState = "scene1";

    public int grade1 = 0;
    public int grade2 = 0;

    [Header("Outside Connections")]
    public DialogueAgent agent;
    public Canvas talking;
    public TextAsset mothman1;
    public TextAsset mothman2;
    public KeyGameState keyGame;
    public Transform hand;
    public Transform report;
    public TextMeshProUGUI grades;

    public void UpdateGamestate()
    {
        tracker++;
        switch (tracker)
        {
            case 1:
                currentGameState = "key1";
                break;
            case 2:
                currentGameState = "scene2";
                break;
            case 3:
                currentGameState = "key2";
                break;
            case 4:
                currentGameState = "report";
                break;
        }
    }

    public string GetGamestate()
    {
        return currentGameState;
    }
}