using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShoppingTransitionManager : MonoBehaviour {

    public Button continueButton;

    private void Awake()
    {
        continueButton.gameObject.SetActive(false);
    }

    public void ShoppingContinueButtonClick()
    {
        SceneManager.LoadScene("Inventory&Marketplace");
    }

    public void SetContinueButtonVisible()
    {
        continueButton.gameObject.SetActive(true);
    }
}
