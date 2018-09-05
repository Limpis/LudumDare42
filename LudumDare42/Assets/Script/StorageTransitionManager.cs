using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageTransitionManager : MonoBehaviour {

    public Button storageContinueButton;
    public ItemSlot[] playerInventorySlots;

    private bool itemSlotsEmpty = false;

    private void Start()
    {
        storageContinueButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (storageContinueButton.gameObject.activeSelf == false)
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
}
