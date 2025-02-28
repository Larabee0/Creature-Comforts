using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor.SearchService;
using UnityEngine;

public class NeoSceneChange : MonoBehaviour
{
    public Canvas desk;
    public Canvas keys;
    public Canvas talk;
    public Canvas note;

    [SerializeField] Canvas currentCanvas;

    public GameState gamestate;

    private void Start()
    {
        currentCanvas = desk;
        keys.enabled = false;
        talk.enabled = false;
        note.enabled = false;
        gamestate.talking.enabled = false;
    }

    void Update()
    {
        if      (Input.GetKeyDown(KeyCode.LeftArrow)  || Input.GetKeyDown(KeyCode.A))
            ChangeScene(0);
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            ChangeScene(1);
        else if (Input.GetKeyDown(KeyCode.UpArrow)    || Input.GetKeyDown(KeyCode.W))
            ChangeScene(2);
        else if (Input.GetKeyDown(KeyCode.DownArrow)  || Input.GetKeyDown(KeyCode.S))
            ChangeScene(3);
    }

    void ChangeScene(int dir)
    {
        // dir 0 = left
        // dir 1 = right
        // dir 2 = up
        // dir 3 = down

        if (currentCanvas == desk)
        {
            if (gamestate.currentGameState != "report")
            switch (dir)
            {
                case 0:
                    currentCanvas = keys;
                    UpdateScene();
                    if (gamestate.currentGameState == "key1")
                    {
                        gamestate.keyGame.StartKeyGame(5);
                    }
                    else if (gamestate.currentGameState == "key2")
                    {
                        gamestate.keyGame.StartKeyGame(10);
                    }
                    break;
                case 1:
                    currentCanvas = note;
                    UpdateScene();
                    break;
                case 2:
                    currentCanvas = talk;
                    UpdateScene();
                    if (gamestate.currentGameState == "scene1")
                    {
                        gamestate.talking.enabled = true;
                        gamestate.agent.inkJSONAsset = gamestate.mothman1;
                        gamestate.agent.StartStory();
                    }
                    else if (gamestate.currentGameState == "scene2")
                    {
                        gamestate.talking.enabled = true;
                        gamestate.agent.inkJSONAsset = gamestate.mothman2;
                        gamestate.agent.StartStory();
                    }
                    break;
                default:
                    break;
            }
        }
        else if (currentCanvas == keys)
        {
            if (dir == 1 && gamestate.currentGameState != "key1" && gamestate.currentGameState != "key2")
            {
                currentCanvas = desk;
                UpdateScene();
            }
        }
        else if (currentCanvas == note)
        {
            if (dir == 0)
            {
                currentCanvas = desk;
                UpdateScene();
            }
        }
        else if (currentCanvas == talk)
        {
            if (dir == 3 && gamestate.currentGameState != "scene1" && gamestate.currentGameState != "scene2")
            {
                currentCanvas = desk;
                UpdateScene();
            }
        }
    }

    void UpdateScene()
    {
        if      (currentCanvas == desk)
        {
            desk.enabled = true ;
            keys.enabled = false;
            talk.enabled = false;
            note.enabled = false;
        }
        else if (currentCanvas == keys)
        {
            desk.enabled = false;
            keys.enabled = true ;
            talk.enabled = false;
            note.enabled = false;
        }
        else if (currentCanvas == talk)
        {
            desk.enabled = false;
            keys.enabled = false;
            talk.enabled = true ;
            note.enabled = false;
        }
        else if (currentCanvas == note)
        {
            desk.enabled = false;
            keys.enabled = false;
            talk.enabled = false;
            note.enabled = true ;
        }
    }
}
