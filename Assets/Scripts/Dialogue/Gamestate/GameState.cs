using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    int tracker = 0;
    
    public string currentGameState = "scene1";

    char grade1 = 'B';
    char grade2 = 'B';

    [Header("Outside Connections")]
    public DialogueAgent agent;
    public Canvas talking;
    public TextAsset mothman1;
    public TextAsset mothman2;
    public KeyGameState keyGame;

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