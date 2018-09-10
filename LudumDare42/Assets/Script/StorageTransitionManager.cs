using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageTransitionManager : MonoBehaviour {

    public Button storageContinueButton;
    public ItemSlot[] playerInventorySlots;
    public GameObject marketplacePanel;

    private bool itemSlotsEmpty = false;

    private void Start()
    {
        storageContinueButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (marketplacePanel.gameObject.activeSelf != true && storageContinueButton.gameObject.activeSelf == false)
        {
            for (int i = 0; i < playerInventorySlots.Length; i++)
            {
                if (playerInventorySlots[i].GetItem() != null)
                {
                    return;
                }
            }
            storageContinueButton.gameObject.SetActive(true);
        }
    }

    public void StorageContinueButtonClick()
    {
        for (int i = 0; i < playerInventorySlots.Length; i++)
        {
            playerInventorySlots[i].transform.parent.gameObject.SetActive(false);
        }

        marketplacePanel.SetActive(true);

        if (!marketplacePanel.GetComponent<Marketplace>().isInitialized)
        {
            marketplacePanel.GetComponent<Marketplace>().RandomizeItems();
        }
        else
        {
            marketplacePanel.GetComponent<Marketplace>().FillEmptySlots();
        }

        storageContinueButton.gameObject.SetActive(false);
    }
}
