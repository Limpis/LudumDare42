using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int value;
    public int price;
    public bool isFoodItem;
    public string itemName;

    public GameObject[] itemCombinations;

    public GameObject[] craftingResult;

    private void Start()
    {
        price = value;
    }

    public int GetValue()
    {
        return value;
    }

    public string GetName()
    {
        return itemName;
    }

    public void SetPrice(float priceFactor)
    {
        price = (int)(value * priceFactor);
    }

    public int GetPrice()
    {
        return price;
    }
}
