using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShoppingTransitionManager : MonoBehaviour {

    public Button continueButton;
    public GameObject StoragePanel;
    public PlayerMoney playerMoney;
    public GameObject[] sellCamelButtons;

    private void Awake()
    {
        continueButton.gameObject.SetActive(false);
    }

    public void ShoppingContinueButtonClick()
    {
        playerMoney.RemoveExtraMoney();
        StoragePanel.SetActive(true);
        for (int i = 0; i < sellCamelButtons.Length; i++)
        {
            sellCamelButtons[i].SetActive(false);
        }

        gameObject.SetActive(false);
    }

    public void SetContinueButtonVisible()
    {
        continueButton.gameObject.SetActive(true);
    }
}
