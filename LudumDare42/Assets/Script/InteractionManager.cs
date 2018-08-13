using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {

    //TODO - Add mousecursor to active item transfer.

    private bool activeItemTransfer = false;
    private ItemSlot activeItemSlot;
    private GameObject itemInTransfer;
    private PlayerMoney playerMoney;

    //Mouse cursor variables
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public Text helpTextLable;
    private bool messageShowing = false;

    public int camelValue = 100;

    private ShoppingTransitionManager transitionManager;
    private int camelCount = 4;

    private void Awake()
    {
        playerMoney = GetComponentInChildren<PlayerMoney>();
        helpTextLable.gameObject.SetActive(false);
    }

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
                DisplayHelpTextMessage("No item exists in item slot");
                Debug.Log("No item exists in item slot");
            }
        }
        else if(activeItemTransfer == true)
        {
            //Check if clicked itemslot destination is empty
            if(itemSlot.GetItem() == null)
            {
                Debug.Log("Transfer allowed...now checking if purchase is made.");
                
                //Check if basic transfer or transfer between seller and player.
                if(itemSlot.CompareTag("PlayerItemSlot"))
                {
                    //Player item slot clicked, check if active itemslot is sellers
                    //if so, transaction is made.

                    if (activeItemSlot.CompareTag("SellerItemSlot"))
                    {
                        int cost = activeItemSlot.heldItem.GetComponent<Item>().GetValue();
                        //Check if affordable
                        if (playerMoney.GetMoney() >= cost)
                        {
                            playerMoney.RemovePlayerMoney(cost);

                            TransferItem(itemSlot);
                            DisplayHelpTextMessage("You bought " + itemSlot.heldItem.GetComponent<Item>().GetName());

                            if (transitionManager == null)
                            {
                                transitionManager = GetComponentInParent<ShoppingTransitionManager>();
                                transitionManager.SetContinueButtonVisible();
                            }

                        }
                        else
                        {
                            DisplayHelpTextMessage("Cannot afford purchase");
                            Debug.Log("Cannot afford purchase");
                        }
                    }
                    else
                    {
                        TransferItem(itemSlot);
                    }
                }
                else if(itemSlot.CompareTag("SellerItemSlot"))
                {
                    //Seller item slot clicked, check if active itemslot is players
                    //if so, transfer is illegal.

                    if(activeItemSlot.CompareTag("PlayerItemSlot"))
                    {
                        Debug.Log("item transfer illegal!");
                        DisplayHelpTextMessage("You are not allowed to sell items right now!");
                    }
                    else
                    {
                        TransferItem(itemSlot);
                    }
                }
                else
                {
                    Debug.Log("Error! Could not find recognizable tag for item slot.");
                }

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
                DisplayHelpTextMessage("An item already exists in this slot.");
            }
        }
    }

    public void SellCamelButtonClick(GameObject camel)
    {
        if (camelCount > 1)
        {
            if (camel.GetComponentInChildren<ItemSlot>().heldItem != null)
            {
                DisplayHelpTextMessage("Cannot sell a camel with a filled inventory");
            }
            else
            {
                camel.SetActive(false);
                playerMoney.AddExtraMoney(camelValue);
                DisplayHelpTextMessage("Camel sold for " + camelValue + " extra coins.");
                camelCount--;
            }
        }
        else
        {
            DisplayHelpTextMessage("Cannot sell your last camel.");
        }
    }

    private void TransferItem(ItemSlot i)
    {
        i.PlaceItem(itemInTransfer);
        activeItemSlot.DropItem();
        activeItemSlot.UpdateItemImage();
        activeItemTransfer = false;
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    private void DisplayHelpTextMessage(string s)
    {
        if (messageShowing == false)
        {
            helpTextLable.text = s;
            helpTextLable.gameObject.SetActive(true);
            messageShowing = true;
            StartCoroutine(DisplayMessage());
        }
        else if(messageShowing == true)
        {
            StopCoroutine(DisplayMessage());
            messageShowing = false;
            helpTextLable.gameObject.SetActive(false);
            DisplayHelpTextMessage(s);
        }
    }

    IEnumerator DisplayMessage()
    {
        yield return new WaitForSeconds(3);
        messageShowing = false;
        helpTextLable.gameObject.SetActive(false);
    }

}
