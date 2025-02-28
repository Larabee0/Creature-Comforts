using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickMothman : MonoBehaviour
{
    public BullyMothman bm;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Moth);
    }

    void Moth()
    {
        bm.Upset();
    }
}
