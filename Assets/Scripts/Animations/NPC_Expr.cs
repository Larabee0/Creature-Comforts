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
        public List<Sprite> hair;
        public Character(string n, List<Sprite> h, List<Sprite> a, List<Sprite> b, List<Sprite> t)
        {
            name = n;
            heads = h;
            arms = a;
            bodys = b;
            hair = t;
        }
    }

    public List<Character> characters = new List<Character>();

    public Character MakeCharacter(string n, List<Sprite> h, List<Sprite> a, List<Sprite> b, List<Sprite> t)
    {
        return new Character(n, h, a, b, t);
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

    public Sprite GetHead(string n, int h)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == n)
            {
                return characters[i].heads[h];
            }
        }
        Debug.Log("err: no character name match found");
        return null;
    }

    public Sprite GetBody(string n, int b)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == n)
            {
                return characters[i].bodys[b];
            }
        }
        Debug.Log("err: no character name match found");
        return null;
    }

    public Sprite GetArms(string n, int a)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == n)
            {
                return characters[i].arms[a];
            }
        }
        Debug.Log("err: no character name match found");
        return null;
    }

    public Sprite GetHair(string n, int t)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].name == n)
            {
                return characters[i].arms[t];
            }
        }
        Debug.Log("err: no character name match found");
        return null;
    }
}