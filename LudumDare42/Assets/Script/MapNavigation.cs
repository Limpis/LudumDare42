﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNavigation : MonoBehaviour {

    public GameObject shoppingMenu;

    public void ContinentButtonClick(GameObject continentTrader)
    {
        gameObject.SetActive(false);
        shoppingMenu.SetActive(true);
        continentTrader.SetActive(true);
    }
}