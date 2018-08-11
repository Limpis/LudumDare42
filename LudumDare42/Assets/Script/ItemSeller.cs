using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSeller : MonoBehaviour {

    public List<GameObject> possibleItems = new List<GameObject>();
    public List<Button> sellerItemButtons = new List<Button>();

    private void Start()
    {
        for (int i = 0; i < sellerItemButtons.Count; i++)
        {
            int r = Random.Range(0, possibleItems.Count);

            ItemSlot itemSlot;
            itemSlot = sellerItemButtons[i].GetComponent<ItemSlot>();
            itemSlot.PlaceItem(possibleItems[r]);
            possibleItems.RemoveAt(r);
        }
    }
}
