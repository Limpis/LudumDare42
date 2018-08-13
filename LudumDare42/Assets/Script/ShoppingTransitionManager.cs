using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingTransitionManager : MonoBehaviour {

    public Button continueButton;

    private void Awake()
    {
        continueButton.gameObject.SetActive(false);
    }

    public void ShoppingContinueButtonClick()
    {
        Debug.Log("Implement scene transition here");
    }

    public void SetContinueButtonVisible()
    {
        continueButton.gameObject.SetActive(true);
    }
}
