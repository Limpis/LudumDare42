using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {

    //TODO - get image from held item and give it tom button image on startup and item transfer.

    public GameObject heldItem;
    public Image buttonItemSprite;

    private void Start()
    {
        UpdateItemImage();
    }

    public GameObject GetItem()
    {
        return heldItem;
    }

    public void PlaceItem(GameObject item)
    {
        heldItem = item;
        UpdateItemImage();
    }

    public void DropItem()
    {
        heldItem = null;
        UpdateItemImage();
    }

    public void SpriteFade()
    {
        Color currColor = buttonItemSprite.color;

        buttonItemSprite.color = new Color(currColor.r, currColor.g, currColor.b, 0.4f);
    }

    public void UpdateItemImage()
    {
        Color currColor = buttonItemSprite.color;

        buttonItemSprite.color = new Color(currColor.r, currColor.g, currColor.b, 1f);

        if (heldItem == null)
        {
            //No item is held, deactivate button sprite.
            buttonItemSprite.enabled = false;
        }
        else
        {
            //Get image from held item and send to button sprite.
            buttonItemSprite.sprite = heldItem.GetComponent<Image>().sprite;
            buttonItemSprite.enabled = true;
        }
    }
}
