using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SCKeys : MonoBehaviour
{
    public Button bR;

    // Start is called before the first frame update
    void Start()
    {
        bR.onClick.AddListener(SceneChangeRight);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneChangeRight();
        }
    }

    void SceneChangeRight()
    {
        SceneManager.LoadScene("DeskScene");
    }
}
