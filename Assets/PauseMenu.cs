using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject resumeButton;


    void Start()
    {
        Resume();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && Application.platform != RuntimePlatform.WebGLPlayer)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    public void EndGame()
    {
        if ( Application.platform == RuntimePlatform.WebGLPlayer)
        {
            return;
        }
        enabled = false;
        resumeButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
