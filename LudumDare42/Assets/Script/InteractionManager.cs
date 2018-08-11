using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour {

    //TODO - Add mousecursor to active item transfer.

    private bool activeItemTransfer = false;
    private ItemSlot activeItemSlot;
    private GameObject itemInTransfer;

    //Mouse cursor variables
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void ItemSlotButtonClick(ItemSlot itemSlot)
    {
        Debug.Log("Implemented button clicked");

        if(activeItemTransfer == false)
        {
            if (itemSlot.GetItem() != null)
            {
                //No item transfer is active - initiate a new one.
                activeItemTransfer = true;
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                activeItemSlot = itemSlot;
                itemInTransfer = itemSlot.GetItem();
                itemSlot.SpriteFade();
                Debug.Log("Held item is: " + itemInTransfer);
            }
            else
            {
                Debug.Log("No item exists in item slot");
            }
        }
        else if(activeItemTransfer == true)
        {
            //Check if clicked itemslot destination is empty
            if(itemSlot.GetItem() == null)
            {
                Debug.Log("Transfer accepted");
                itemSlot.PlaceItem(itemInTransfer);
                activeItemSlot.DropItem();
                activeItemSlot.UpdateItemImage();
                activeItemTransfer = false;
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
            }
            else if(itemSlot == activeItemSlot)
            {
                Debug.Log("Same itemslot clicked, now deactivating transfer");
                activeItemTransfer = false;
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                activeItemSlot.UpdateItemImage();
            }
            else
            {
                Debug.Log("An item already exists in this slot");
            }
        }
    }

}
