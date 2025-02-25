using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    int tracker = 0;
    public DialogueAgent da;

    public TextAsset scene1;
    public TextAsset scene2;
    
    string currentGameState = "scene1";

    public void UpdateGamestate()
    {
        tracker++;
        switch (tracker)
        {
            case 1:
                currentGameState = "key";
                break;
            case 2:
                currentGameState = "scene2";
                break;
            case 3:
                currentGameState = "key";
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