using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class KeyData : MonoBehaviour
{

    public int[] boardVals = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
    int[] keyVals = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
    public Dictionary<int, int> keyToLocationPairs = new Dictionary<int, int>();
    public Dictionary<int, int> locationToHookPairs = new Dictionary<int, int>();

    public void GenerateBoard()
    {
        System.Random rng = new System.Random();
        ShuffleArray(boardVals, rng);
    }

    public void GenerateKeys(int numberOfKeys = 1)
    {
        if (numberOfKeys > 18)
        {
            Debug.Log("Keys requested: " + numberOfKeys + " | Max keys: 18");
            numberOfKeys = 18;
        }

        System.Random rng = new System.Random();
        ShuffleArray(keyVals, rng);
        ShuffleArray(boardVals, rng);
        for (int i = 0; i < numberOfKeys; i++)
        {
            int keyVal = keyVals[i];
            int hookVal = boardVals[i];

            keyToLocationPairs.Add(keyVal, hookVal);
        }
    }

    public void PlaceKey(int key, int hook)
    {
        keyToLocationPairs[key] = hook;
    }

    public bool CheckForSuccess()
    {
        foreach(KeyValuePair<int, int> khp in keyToLocationPairs)
        {
            if (khp.Key != khp.Value)
                return false;
        }
        return true;
    }

    public void ClearKeys()
    {
        keyToLocationPairs.Clear();
    }

    void ShuffleArray(int[] array, System.Random rng)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            int temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}
