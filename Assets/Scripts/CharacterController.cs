using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{


    private static Dictionary<string, GameObject> augmentations;

    public Character[] characters;
    // Start is called before the first frame update
    void Start()
    {
        augmentations = new Dictionary<string, GameObject>();

        for (int a = 0; a < characters.Length; ++a)
        {
            augmentations.Add(characters[a].name,
                              characters[a].character);
        }
    }




   public static GameObject GetValuefromDictionary(string key)
    {
        Debug.Log("<color=blue>GetValuefromDictionary() called.</color>");
        if (augmentations == null)
            Debug.Log("dictionary is null");

        if (augmentations.ContainsKey(key))
        {
            Debug.Log("key: " + key);
            GameObject value;
            augmentations.TryGetValue(key, out value);
            Debug.Log("value: " + value.name);
            return value;
        }

        return null;
        //return "Key not found.";
    }

    
}
