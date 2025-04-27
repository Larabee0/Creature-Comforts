using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeoSceneChange : MonoBehaviour
{
    public Canvas desk;
    public Canvas keys;
    public Canvas talk;
    public Canvas note;
    public Canvas loby;
    public Button mothmanB;
    public Button nessieB;
    public Button keyNavRight;

    [SerializeField] Canvas currentCanvas;

    public GameState gamestate;

    private void Start()
    {
        currentCanvas = desk;
        keys.enabled = false;
        talk.enabled = false;
        note.enabled = false;
        loby.enabled = false;
        gamestate.talking.enabled = false;
        mothmanB.onClick.AddListener(MothmanButtonClick);
        nessieB.onClick.AddListener(NessieButtonClick);
        gamestate.HideKeyHud();
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

    public void ChangeScene(int dir)
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
                        keyNavRight.gameObject.SetActive(false);
                        UpdateScene();
                        if (gamestate.currentGameState == "key1" || gamestate.currentGameState == "key2" || gamestate.currentGameState == "key3")
                        {
                            gamestate.keyGame.ShowPlayButton();
                        }
                        break;
                    case 1:
                        currentCanvas = note;
                        UpdateScene();
                        break;
                    case 2:
                        if (gamestate.currentGameState == "m_d1_s1" || gamestate.currentGameState == "m_d1_s2" || gamestate.currentGameState == "m_d2_s1" || gamestate.currentGameState == "m_d2_s2" || gamestate.currentGameState == "m_d3_s1")
                        {
                            mothmanB.GetComponent<Image>().enabled = true;

                            if (gamestate.currentGameState == "m_d1_s1" || gamestate.currentGameState == "m_d1_s2")
                            {
                                gamestate.ShowMothmanDialgoueHud();
                            }
                            mothmanB.enabled = true;
                        }
                        else
                        {
                            gamestate.HideMothmanDialgoueHud();
                            mothmanB.GetComponent<Image>().enabled = false;
                            mothmanB.enabled = false;
                        }
                        if (gamestate.currentGameState == "n_d1_s1" || gamestate.currentGameState == "n_d1_s2" || gamestate.currentGameState == "n_d2_s1" || gamestate.currentGameState == "n_d2_s2" || gamestate.currentGameState == "n_d3_s1")
                        {
                            if (gamestate.currentGameState == "n_d1_s1" || gamestate.currentGameState == "n_d1_s2")
                            {
                                gamestate.ShowNessieDialgoueHud();
                            }
                            nessieB.GetComponent<Image>().enabled = true;
                            nessieB.enabled = true;
                        }
                        else
                        {
                            gamestate.HideNessieDialgoueHud();
                            nessieB.GetComponent<Image>().enabled = false;
                            nessieB.enabled = false;
                        }
                        currentCanvas = loby;
                        UpdateScene();
                        break;
                }
        }
        else if (currentCanvas == keys)
        {
            if (dir == 1 && gamestate.currentGameState != "key1" && gamestate.currentGameState != "key2")
            {
                keyNavRight.gameObject.SetActive(false);
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
            if (dir == 3 && gamestate.currentGameState != "m_d1_s1" && gamestate.currentGameState != "m_d1_s2" && gamestate.currentGameState != "n_d1_s1" && gamestate.currentGameState != "n_d1_s2" && gamestate.currentGameState != "m_d2_s1" && gamestate.currentGameState != "m_d2_s2" && gamestate.currentGameState != "n_d2_s1" && gamestate.currentGameState != "n_d2_s2" && gamestate.currentGameState != "m_d3_s1" && gamestate.currentGameState != "n_d3_s1")
            {
                if (gamestate.currentGameState == "report")
                {
                    Report();
                }
                else if(gamestate.currentGameState == "final_report")
                {
                    FinalReport();
                }
                currentCanvas = desk;
                gamestate.HideDialogueHud();
                UpdateScene();
            }
        }
        else if (currentCanvas = loby)
        {
            if (dir == 3)
            {
                currentCanvas = desk;
                UpdateScene();
            }
        }
    }

    void MothmanButtonClick()
    {
        currentCanvas = talk;
        UpdateScene();
        gamestate.agent.npcTalking = "Mothman";

        gamestate.talking.enabled = true;
        mothmanB.GetComponent<Image>().enabled = false;
        mothmanB.enabled = false;

        if      (gamestate.currentGameState == "m_d1_s1")
            gamestate.agent.inkJSONAsset = gamestate.m_d1_s1;
        else if (gamestate.currentGameState == "m_d1_s2")
            gamestate.agent.inkJSONAsset = gamestate.m_d1_s2;
        else if (gamestate.currentGameState == "m_d2_s1")
            gamestate.agent.inkJSONAsset = gamestate.m_d1_s2;
        else if (gamestate.currentGameState == "m_d2_s2")
            gamestate.agent.inkJSONAsset = gamestate.m_d1_s2;
        else if (gamestate.currentGameState == "m_d3_s1")
            gamestate.agent.inkJSONAsset = gamestate.m_d1_s2;

        gamestate.agent.StartStory();
    }

    void NessieButtonClick()
    {
        currentCanvas = talk;
        UpdateScene();
        gamestate.agent.npcTalking = "Nessie";

        gamestate.talking.enabled = true;
        mothmanB.GetComponent<Image>().enabled = false;
        mothmanB.enabled = false;

        if      (gamestate.currentGameState == "n_d1_s1")
            gamestate.agent.inkJSONAsset = gamestate.n_d1_s1;
        else if (gamestate.currentGameState == "n_d1_s2")
            gamestate.agent.inkJSONAsset = gamestate.n_d1_s2;
        else if (gamestate.currentGameState == "n_d2_s1")
            gamestate.agent.inkJSONAsset = gamestate.n_d1_s2;
        else if (gamestate.currentGameState == "n_d2_s2")
            gamestate.agent.inkJSONAsset = gamestate.n_d1_s2;
        else if (gamestate.currentGameState == "n_d3_s1")
            gamestate.agent.inkJSONAsset = gamestate.n_d1_s2;

        gamestate.agent.StartStory();
    }

    void UpdateScene()
    {
        if      (currentCanvas == desk)
        {
            desk.enabled = true ;
            keys.enabled = false;
            talk.enabled = false;
            note.enabled = false;
            loby.enabled = false;
        }
        else if (currentCanvas == keys)
        {
            desk.enabled = false;
            keys.enabled = true ;
            talk.enabled = false;
            note.enabled = false;
            loby.enabled = false;
        }
        else if (currentCanvas == talk)
        {
            desk.enabled = false;
            keys.enabled = false;
            talk.enabled = true ;
            note.enabled = false;
            loby.enabled = false;
        }
        else if (currentCanvas == note)
        {
            desk.enabled = false;
            keys.enabled = false;
            talk.enabled = false;
            note.enabled = true ;
            loby.enabled = false;
        }
        else if (currentCanvas == loby)
        {
            desk.enabled = false;
            keys.enabled = false;
            talk.enabled = false;
            note.enabled = false;
            loby.enabled = true ;
        }
    }

    private void FinalReport()
    {
        gamestate.reportSlide.SlideFinalReport();
    }

    void Report()
    {
        string g = "Keys: ";
        for (int i = 0; i < gamestate.gradeList.Count; i++)
        {
            if (gamestate.gradeList[i] == 4)
            {
                g += "A";
            }
            else if (gamestate.gradeList[i] == 3)
            {
                g += "B";
            }
            else if (gamestate.gradeList[i] == 2)
            {
                g += "C";
            }
            else if (gamestate.gradeList[i] == 1)
            {
                g += "F";
            }

            if (i < gamestate.gradeList.Count - 1)
            {
                g += ", ";
            }
        }
        gamestate.grades.text = g;

        int val = 0;
        for (int i = 0; i < gamestate.gradeList.Count; i++)
        {
            val += gamestate.gradeList[i]; 
        }
        gamestate.reportSlide.finalGrade.sprite = gamestate.reportSlide.gradeImgs [(int)((float)val / (float)gamestate.gradeList.Count)];
        gamestate.reportSlide.bossQoute .sprite = gamestate.reportSlide.bossQoutes[(int)((float)val / (float)gamestate.gradeList.Count)];

        gamestate.reportSlide.SlideReport();
    }
}
