using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HungKeyEnabler : MonoBehaviour
{
    public Image key15;
    public Image key15_follow;
    public Button b15;
    public bool b15Hooked = false;

    private void Start()
    {
        b15.onClick.AddListener(ShowKey15);
    }

    public void ShowKey15()
    {
        key15.enabled = true;
        key15.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        key15_follow.enabled = false;
        key15_follow.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        b15Hooked = true;
    }
}
