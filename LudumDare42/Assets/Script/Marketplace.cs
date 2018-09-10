using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marketplace : MonoBehaviour {

    public GameObject storagePanel;
    public GameObject worldMapPanel;
    public GameObject playerInventoryPanel;

    public List<GameObject> possibleItems = new List<GameObject>();
    public List<Button> marketItemButtons = new List<Button>();

    public float marketPriceFactor;
    public bool isInitialized = false;

    public void RandomizeItems()
    {
        List<GameObject> tempItems = new List<GameObject>(possibleItems);

        for (int i = 0; i < tempItems.Count; i++)
        {
            tempItems[i].GetComponent<Item>().SetPrice(marketPriceFactor);

        }

        for (int i = 0; i < marketItemButtons.Count; i++)
        {
            int r = Random.Range(0, tempItems.Count);

            ItemSlot itemSlot;
            itemSlot = marketItemButtons[i].GetComponent<ItemSlot>();
            itemSlot.PlaceItem(tempItems[r]);
            tempItems.RemoveAt(r);
        }
    }

    public void FillEmptySlots()
    {
        for (int i = 0; i < marketItemButtons.Count; i++)
        {
            ItemSlot checkedSlot = marketItemButtons[i].GetComponent<ItemSlot>();

            checkedSlot.GetItem().GetComponent<Item>().SetPrice(marketPriceFactor);

            if (checkedSlot.GetItem() == null)
            {
                checkedSlot.gameObject.SetActive(true);

                int r = Random.Range(0, possibleItems.Count);

                checkedSlot.PlaceItem(possibleItems[r]);
            }
        }
    }

    public void WorldMapButtonClicked()
    {
        storagePanel.gameObject.SetActive(false);
        playerInventoryPanel.gameObject.SetActive(false);
        gameObject.SetActive(false);
        worldMapPanel.gameObject.SetActive(true);

        for (int i = 0; i < marketItemButtons.Count; i++)
        {
            marketItemButtons[i].gameObject.SetActive(true);
        }
    }
}
