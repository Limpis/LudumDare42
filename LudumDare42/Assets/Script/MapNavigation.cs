using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNavigation : MonoBehaviour {

    public GameObject shoppingMenu;
    public GameObject playerPanel;
    public GameObject[] camelButtons;
    public GameObject[] sellCamelButtons;

    public void ContinentButtonClick(GameObject continentTrader)
    {
        gameObject.SetActive(false);
        shoppingMenu.SetActive(true);
        continentTrader.SetActive(true);
        playerPanel.SetActive(true);

        for (int i = 0; i < camelButtons.Length; i++)
        {
            camelButtons[i].SetActive(true);
            sellCamelButtons[i].SetActive(true);
        }

        continentTrader.GetComponent<ItemSeller>().RandomizeItems();
    }
}
