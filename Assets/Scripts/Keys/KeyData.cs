using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyData : MonoBehaviour
{
    Dictionary<int, int> KeyToHookPairs = new Dictionary<int, int>();

    void GenerateKeys(int numberOfKeys = 1)
    {
        if (numberOfKeys > 18)
        {
            Debug.Log("Keys requested: " + numberOfKeys + " | Max keys: 18");
            numberOfKeys = 18;
        }

        for (int i = 0; i < numberOfKeys; i++)
        {
            int keyVal = 1; // get unique random number 1 to number of hooks
            int hookVal = 1; // get unique random number 1 to number of hooks 

            KeyToHookPairs.Add(keyVal, hookVal);
        }
    }

    void PlaceKey(int key, int hook)
    {
        KeyToHookPairs[key] = hook;
    }

    bool CheckForSuccess()
    {
        foreach(KeyValuePair<int, int> khp in KeyToHookPairs)
        {
            if (khp.Key != khp.Value)
                return false;
        }
        return true;
    }
}
