using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayPressed : MonoBehaviour
{
    [SerializeField] private GameObject exitButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Play);
        if(Application.platform == RuntimePlatform.WebGLPlayer)
        {
            exitButton.SetActive(false);
        }
        exitButton.GetComponent<Button>().onClick.AddListener(Application.Quit);
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }
}
