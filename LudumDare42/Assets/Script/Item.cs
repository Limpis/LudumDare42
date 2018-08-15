using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int value;
    public bool isFoodItem;
    public string itemName;

    public GameObject[] itemCombinations;

    public GameObject[] craftingResult;

    public int GetValue()
    {
        return value;
    }

    public string GetName()
    {
        return itemName;
    }
}
