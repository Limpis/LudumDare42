using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGame : MonoBehaviour
{
    public GameObject worldMapPanel;
    public GameObject shoppingPanel;
    public GameObject playerPanel;
    public GameObject playerInventoryPanel;
    public GameObject storagePanel;
    public GameObject marketplacePanel;

    private void Start()
    {
        worldMapPanel.SetActive(true);
        shoppingPanel.SetActive(false);
        playerPanel.SetActive(true);
        playerInventoryPanel.SetActive(false);
        storagePanel.SetActive(false);
        marketplacePanel.SetActive(false);
    }
}
