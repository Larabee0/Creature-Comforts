using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    public bool moving = false;
    [SerializeField]
    GameState gs;

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position += transform.up * - Time.deltaTime * 180;
            if (transform.position.y < -240)
            {
                moving = false;
                gs.UpdateGamestate();
            }
        }
    }
}
