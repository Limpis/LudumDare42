using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour {

    public int money = 300;
    public Text playerMoneyLable;

    private void Start()
    {
        UpdatePlayerMoney();
    }

    public void UpdatePlayerMoney()
    {
        playerMoneyLable.text = money.ToString();
    }

    public void RemovePlayerMoney(int cost)
    {
        money -= cost;
        UpdatePlayerMoney();
    }

    public void AddPlayerMoney(int pay)
    {
        money += pay;
        UpdatePlayerMoney();
    }
}
