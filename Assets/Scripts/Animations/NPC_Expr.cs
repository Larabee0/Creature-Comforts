using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Expr : MonoBehaviour
{
    public Dictionary<string, List<Sprite>> characterExpressions = new Dictionary<string, List<Sprite>>();

    public Sprite getExpression(string nametag, int expressionIndex) {
        return characterExpressions[nametag][expressionIndex];
    }
}