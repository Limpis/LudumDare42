using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour {


    public ItemSlot itemSlot1;
    public ItemSlot itemSlot2;
    public Button craftingButton;

    int indexMatch;

    bool allowCrafting;

	// Use this for initialization
	void Start ()
    {
        craftingButton.gameObject.SetActive(false);
        allowCrafting = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(itemSlot1.heldItem != null && itemSlot2.heldItem != null)
        {
            CheckForCombinations();
            craftingButton.gameObject.SetActive(true);
        }

        

    }

    public void CheckForCombinations()
    {
        GameObject[] itemCombinations = itemSlot1.heldItem.GetComponent<Item>().itemCombinations;

        for (int i = 0; i < itemCombinations.Length; i++)
        {
              if(itemCombinations[i] == itemSlot2.heldItem)
            {
                indexMatch = i;
                allowCrafting = true;
                break;
            }
        }
        
    }



    public void CombineItems()
    {
        GameObject[] craftingResult = itemSlot1.heldItem.GetComponent<Item>().craftingResult;

        if(allowCrafting)
        {
            Debug.Log("Combined Items");
            itemSlot1.DropItem();
            itemSlot2.DropItem();
            itemSlot1.PlaceItem(craftingResult[indexMatch]);
            allowCrafting = false;
        }
        
    }
}
