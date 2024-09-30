using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCDesk : MonoBehaviour
{
    public Button bL;
    public Button bR;
    public Button bU;
    public Button bD;

    // Start is called before the first frame update
    void Start()
    {
        bL.onClick.AddListener(SceneChangeLeft);
        bR.onClick.AddListener(SceneChangeRight);
        bU.onClick.AddListener(SceneChangeUp);
        bD.onClick.AddListener(SceneChangeDown);
    }

    void SceneChangeLeft()
    {
        SceneManager.LoadScene("");
    }

    void SceneChangeRight()
    {
        SceneManager.LoadScene("");
    }

    void SceneChangeUp()
    {
        SceneManager.LoadScene("");
    }

    void SceneChangeDown()
    {
        SceneManager.LoadScene("");
    }
}
