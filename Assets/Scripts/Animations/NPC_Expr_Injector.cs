using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Expr_Injector : MonoBehaviour
{
    [SerializeField] string nameTag;
    public List<Sprite> spriteList = new List<Sprite>();
    void Start()
    {
        GetComponent<NPC_Expr>().characterExpressions.Add(nameTag, spriteList);
    }
}
