using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour {

    public int playerMoney = 300;
    public Text playerMoneyLable;

    private void Start()
    {
        UpdatePlayerMoney();
    }

    public void UpdatePlayerMoney()
    {
        playerMoneyLable.text = playerMoney.ToString();
    }

    public void RemovePlayerMoney(int cost)
    {
        playerMoney -= cost;
        UpdatePlayerMoney();
    }

    public void AddPlayerMoney(int pay)
    {
        playerMoney += pay;
        UpdatePlayerMoney();
    }
}
