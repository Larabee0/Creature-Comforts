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
    public TextAsset m_d2_s1;
    public TextAsset m_d2_s2;
    public TextAsset n_d2_s1;
    public TextAsset n_d2_s2;
    public TextAsset m_d3_s1;
    public TextAsset n_d3_s1;
    public KeyGameState keyGame;
    public ReportSlide reportSlide;
    public TextMeshProUGUI grades;
    public List<Image> keyHud = new List<Image>();
    public List<Image> dialogueHud = new List<Image>();
    public Image mothmanDialogueHudLobby;
    public Image nessieDialogueHudLobby;
    public int nessieSentiment = 0, mothmanSentiment = 0;
    public DayChange dc;
    public Music music;

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
                music.SwapSong();
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
            case 8:
                currentGameState = "newDay";
                dc.StartFade(2);
                break;
            case 9:
                music.SwapSong();
                currentGameState = "m_d2_s1";
                break;
            case 10:
                currentGameState = "key2";
                break;
            case 11:
                currentGameState = "n_d2_s1";
                break;
            case 12:
                currentGameState = "key2";
                break;
            case 13:
                music.SwapSong();
                currentGameState = "n_d2_s2";
                break;
            case 14:
                currentGameState = "key3";
                break;
            case 15:
                currentGameState = "m_d2_s2";
                break;
            case 16:
                currentGameState = "report";
                break;
            case 17:
                currentGameState = "newDay";
                dc.StartFade(3);
                break;
            case 18:
                music.SwapSong();
                currentGameState = "key2";
                break;
            case 19:
                currentGameState = "n_d3_s1";
                break;
            case 20:
                currentGameState = "key3";
                break;
            case 21:
                currentGameState = "m_d3_s1";
                break;
            case 22:
                currentGameState = "key3";
                break;
            case 23:
                music.SwapSong();
                currentGameState = "report";
                break;
            case 24:
                currentGameState = "newDay";
                dc.StartFade(4);
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

    public void ShowMothmanDialgoueHud()
    {
        mothmanDialogueHudLobby.enabled = true;
    }

    public void ShowNessieDialgoueHud()
    {
        nessieDialogueHudLobby.enabled = true;
    }

    public void HideMothmanDialgoueHud()
    {
        mothmanDialogueHudLobby.enabled = false;
    }

    public void HideNessieDialgoueHud()
    {
        nessieDialogueHudLobby.enabled = false;
    }

    public string GetGamestate()
    {
        return currentGameState;
    }

    public void ModifySentiment(string name, int modification)
    {
        if (name == "Mothman")
        {
            mothmanSentiment += modification;
        }
        else if (name == "Nessie")
        {
            nessieSentiment += modification;
        }
    }
}