using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGame : MonoBehaviour
{
    public GameObject WorldMapPanel;
    public GameObject ShoppingPanel;
    public GameObject playerPanel;
    public GameObject PlayerInventoryPanel;
    public GameObject StoragePanel;

    private void Start()
    {
        WorldMapPanel.SetActive(true);
        ShoppingPanel.SetActive(false);
        playerPanel.SetActive(true);
        PlayerInventoryPanel.SetActive(false);
        StoragePanel.SetActive(false);
    }
}
