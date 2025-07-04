using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PsudoSceneChange : MonoBehaviour
{
    public Bell bell;
    //public HungKeyEnabler hke;
    public DialogueInteractor di;
    public DialogueAgent agent;

    public Canvas desk;
    public Canvas customer;
    public Canvas keys;
    public Canvas computer;
    public Canvas board;

    public int LRVal = 1;
    public int UDVal = 1;
    public bool tutorial = false;
    public DialogueInteractor interactor;

    private void Start()
    {
        UpdateCanvass();
        agent = GetComponent<DialogueAgent>();
    }

    void Update()
    {
        if (!tutorial)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && LRVal < 2)
            {
                LRVal++;
                UpdateCanvass();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && LRVal > 0)
            {
                LRVal--;
                UpdateCanvass();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && UDVal < 2)
            {
                UDVal++;
                UpdateCanvass();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && UDVal > 0)
            {
                UDVal--;
                UpdateCanvass();
            }
        }
    }

    public void UpdateCanvass()
    {
        if (LRVal == 0)
        {
            keys.enabled     = true;
            customer.enabled = false;
            desk.enabled     = false;
            board.enabled    = false;
            computer.enabled = false;
        }
        else if (LRVal == 2)
        {
            keys.enabled     = false;
            customer.enabled = false;
            desk.enabled     = false;
            board.enabled    = true;
            computer.enabled = false;
        }
        else if (UDVal == 0)
        {
            keys.enabled     = false;
            customer.enabled = false;
            desk.enabled     = false;
            board.enabled    = false;
            computer.enabled = true;
        }
        else if (UDVal == 2)
        {
            keys.enabled     = false;
            customer.enabled = true;
            desk.enabled     = false;
            board.enabled    = false;
            computer.enabled = false;
            agent.StartStory();
            //if (hke.b15Hooked)
            //{
            //    di.StartTalking(1);
            //}
        }
        else
        {
            keys.enabled     = false;
            customer.enabled = false;
            desk.enabled     = true;
            board.enabled    = false;
            computer.enabled = false;
        }
    }
}
