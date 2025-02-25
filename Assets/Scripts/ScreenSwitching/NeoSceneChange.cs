using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class NeoSceneChange : MonoBehaviour
{
    public Canvas desk;
    public Canvas keys;
    public Canvas talk;
    public Canvas note;

    Canvas currentCanvas;

    private void Start()
    {
        currentCanvas = desk;
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
            switch (dir)
            {
                case 0:
                    currentCanvas = keys;
                    UpdateScene();
                    break;
                case 1:
                    currentCanvas = note;
                    UpdateScene();
                    break;
                case 2:
                    currentCanvas = talk;
                    UpdateScene();
                    break;
                default:
                    break;
            }
        }
        else if (currentCanvas == keys)
        {
            if (dir == 1)
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
            if (dir == 3)
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
