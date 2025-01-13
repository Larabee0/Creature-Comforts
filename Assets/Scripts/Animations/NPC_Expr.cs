using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Expr : MonoBehaviour
{
    public struct Character
    {
        public string name;
        public List<Sprite> heads;
        public List<Sprite> arms;
        public List<Sprite> bodys;
        public Character(string n, List<Sprite> h, List<Sprite> a, List<Sprite> b)
        {
            name = n;
            heads = h;
            arms = a;
            bodys = b;
        }
    }
    public List<Character> characters;

    public Character MakeCharacter(string n, List<Sprite> h, List<Sprite> a, List<Sprite> b)
    {
        return new Character(n, h, a, b);
    }

    public Sprite[] GetSprites(string n, int h, int a, int b)
    {
        Sprite head = null;
        Sprite arms = null;
        Sprite body = null;

        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == n)
            {
                head = characters[i].heads[h];
                arms = characters[i].arms[a];
                body = characters[i].bodys[b];
            }
        }
        Sprite[] arr = { head, arms, body };
        return arr;
    }
}