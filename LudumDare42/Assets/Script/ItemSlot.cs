using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {

    public GameObject heldItem;
    public Image buttonItemSprite;
    public Text priceLable;
    public bool isFridge = false;

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

        if (priceLable != null)
        {
            if (priceLable.enabled == false)
            {
                priceLable.enabled = true;
            }
        }

        UpdatePriceLable();
    }

    public void DropItem()
    {
        heldItem = null;
        UpdateItemImage();

        if (priceLable != null)
        {
            priceLable.enabled = false;
        }
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

    public void UpdatePriceLable()
    {
        if(priceLable != null)
        {
            int price = heldItem.GetComponent<Item>().GetPrice();
            priceLable.text = price.ToString();
        }
    }
}
