using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Expr_Injector : MonoBehaviour
{
    [SerializeField] string nameTag;
    public List<Sprite> headList = new List<Sprite>();
    public List<Sprite> armsList = new List<Sprite>();
    public List<Sprite> bodyList = new List<Sprite>();
    public List<Sprite> hairList = new List<Sprite>();

    private void Awake()
    {
        NPC_Expr NPCE = GetComponent<NPC_Expr>();
        NPCE.characters.Add(NPCE.MakeCharacter(nameTag, headList, armsList, bodyList, hairList));
    }
}
