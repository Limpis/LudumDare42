using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCan : MonoBehaviour {

    public ItemSlot trashSlot;

    private void Update()
    {
        if(trashSlot.heldItem != null)
        {
            trashSlot.DropItem();
        }
    }
}
