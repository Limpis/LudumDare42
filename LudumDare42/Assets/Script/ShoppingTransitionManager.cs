using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShoppingTransitionManager : MonoBehaviour {

    public Button continueButton;
    public GameObject StoragePanel;

    private void Awake()
    {
        continueButton.gameObject.SetActive(false);
    }

    public void ShoppingContinueButtonClick()
    {
        StoragePanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SetContinueButtonVisible()
    {
        continueButton.gameObject.SetActive(true);
    }
}
