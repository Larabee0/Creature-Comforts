using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    int tracker = 0;
    
    public string currentGameState = "m_d1_s1";

    public List<int> gradeList = new List<int>();

    [Header("Outside Connections")]
    public DialogueAgent agent;
    public Canvas talking;
    public TextAsset m_d1_s1;
    public TextAsset m_d1_s2;
    public TextAsset n_d1_s1;
    public TextAsset n_d1_s2;
    public KeyGameState keyGame;
    public ReportSlide reportSlide;
    public TextMeshProUGUI grades;
    public List<Image> keyHud = new List<Image>();
    public List<Image> dialogueHud = new List<Image>();

    public void UpdateGamestate()
    {
        tracker++;
        switch (tracker)
        {
            case 1:
                currentGameState = "key1";
                break;
            case 2:
                currentGameState = "n_d1_s1";
                break;
            case 3:
                currentGameState = "key1";
                break;
            case 4:
                currentGameState = "m_d1_s2";
                break;
            case 5:
                currentGameState = "key2";
                break;
            case 6:
                currentGameState = "n_d1_s2";
                break;
            case 7:
                currentGameState = "report";
                break;
        }
    }

    public void ShowKeyHud()
    {
        for (int i = 0; i < keyHud.Count; i++)
        {
            keyHud[i].enabled = true;
        }
    }

    public void HideKeyHud()
    {
        for (int i = 0; i < keyHud.Count; i++)
        {
            keyHud[i].enabled = false;
        }
    }

    public void ShowDialogueHud()
    {
        for (int i = 0; i < dialogueHud.Count; i++)
        {
            dialogueHud[i].enabled = true;
        }
    }

    public void HideDialogueHud()
    {
        for (int i = 0; i < dialogueHud.Count; i++)
        {
            dialogueHud[i].enabled = false;
        }
    }

    public string GetGamestate()
    {
        return currentGameState;
    }
}