using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    public bool holding = false;

    void Update()
    {
        transform.position = Input.mousePosition + offset;
    }
}
