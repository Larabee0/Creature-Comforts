using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    int tracker = 0;
    
    public string currentGameState = "tut_script";

    public List<int> gradeList = new();

    [Header("Outside Connections")]
    public DialogueAgent agent;
    public Canvas talking;
    public Canvas talkingPhone;
    public TextAsset tut_script;
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
    public List<Image> bossHud = new List<Image>();
    public List<Image> dialogueHud = new List<Image>();
    public Image mothmanDialogueHudLobby;
    public Image nessieDialogueHudLobby;
    public int nessieSentiment = 0, mothmanSentiment = 0;
    public DayChange dc;
    public Music music;
    public Wiggle _phoneWiggle;
    public GameObject day1Forms;
    public GeneralAudio generalAudio;

    private void Start()
    {
        HideDialogueHud();
    }

    public void UpdateGamestate()
    {
        tracker++;
        switch (tracker)
        {
            case 1:
                currentGameState = "m_d1_s1";
                ShowDialogueHud();
                break;
            case 2:
                currentGameState = "key1";
                break;
            case 3:
                currentGameState = "n_d1_s1";
                break;
            case 4:
                currentGameState = "key1";
                break;
            case 5:
                music.FadeTo(music.evening);
                currentGameState = "m_d1_s2";
                break;
            case 6:
                currentGameState = "key2";
                break;
            case 7:
                currentGameState = "n_d1_s2";
                break;
            case 8:
                currentGameState = "report";
                break;
            case 9:
                currentGameState = "newDay";
                day1Forms.SetActive(false);
                dc.StartFade(2);
                break;
            case 10:
                music.FadeTo(music.morning);
                _phoneWiggle.SetWiggling(true);
                HideDialogueHud();
                currentGameState = "m_d2_s1";
                break;
            case 11:
                currentGameState = "key2";
                break;
            case 12:
                currentGameState = "n_d2_s1";
                break;
            case 13:
                currentGameState = "key2";
                break;
            case 14:
                music.FadeTo(music.evening);
                currentGameState = "n_d2_s2";
                break;
            case 15:
                currentGameState = "key3";
                break;
            case 16:
                currentGameState = "m_d2_s2";
                break;
            case 17:
                currentGameState = "report";
                break;
            case 18:
                currentGameState = "newDay";
                dc.StartFade(3);
                break;
            case 19:
                music.FadeTo(music.morning);
                ShowKeyHud();
                currentGameState = "key2";
                break;
            case 20:
                currentGameState = "n_d3_s1";
                break;
            case 21:
                currentGameState = "key3";
                break;
            case 22:
                currentGameState = "m_d3_s1";
                break;
            case 23:
                currentGameState = "key3";
                break;
            case 24:
                currentGameState = "report";
                ShowBossReport();
                break;
            case 25:
                music.FadeTo(music.evening);
                currentGameState = "newDay";
                dc.StartFinalFade();
                break;
            case 26:
                currentGameState = "final_report";
                reportSlide.SlideFinalReport();
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
        generalAudio.PlayBell();
    }

    public void HideDialogueHud()
    {
        for (int i = 0; i < dialogueHud.Count; i++)
        {
            dialogueHud[i].enabled = false;
        }
        if(generalAudio.audioSource.clip== generalAudio.bell && generalAudio.audioSource.isPlaying)
        {
            generalAudio.audioSource.Stop();
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

    public void ShowBossReport()
    {
        for (int i = 0; i < bossHud.Count; i++)
        {
            bossHud[i].enabled = true;
        }
    }
    public void HideBossReport()
    {
        for (int i = 0; i < bossHud.Count; i++)
        {
            bossHud[i].enabled = false;
        }
    }
}