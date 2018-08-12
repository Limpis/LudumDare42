using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int value;
    public bool foodItem;
    public string itemName;

    public int GetValue()
    {
        return value;
    }

    public string GetName()
    {
        return itemName;
    }
}
