using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSeller : MonoBehaviour {

    public List<GameObject> possibleItems = new List<GameObject>();
    public List<Button> sellerItemButtons = new List<Button>();

    public float sellerPriceFactor = 0.8f;

    private List<GameObject> tempList;

    public void RandomizeItems()
    {
        tempList = new List<GameObject>(possibleItems);

        for (int i = 0; i < tempList.Count; i++)
        {
            tempList[i].GetComponent<Item>().SetPrice(sellerPriceFactor);
        }

        for (int i = 0; i < sellerItemButtons.Count; i++)
        {
            int r = Random.Range(0, tempList.Count);

            ItemSlot itemSlot;
            itemSlot = sellerItemButtons[i].GetComponent<ItemSlot>();
            itemSlot.PlaceItem(tempList[r]);
            tempList.RemoveAt(r);
        }
    }
}
