using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickDebug : MonoBehaviour
{
    Button b;
    // Start is called before the first frame update
    void Start()
    {
        b=GetComponent<Button>();
        b.onClick.AddListener(Clicked);
    }

    void Clicked()
    {
        Debug.Log("buttonClicked");
    }
}
