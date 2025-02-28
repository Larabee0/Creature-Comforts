using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BullyMothman : MonoBehaviour
{
    public List<Sprite> faces = new List<Sprite>();
    int face = 0;

    public void Upset()
    {
        face++;
        if (face < faces.Count)
        {
            GetComponent<Image>().sprite = faces[face];
        }
    }
}
