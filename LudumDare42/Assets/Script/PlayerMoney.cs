using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour {

    //TODO - implement "extra" money from selling camels, these are not transferable to next round.

    public int money = 300;
    public int extraMoney = 0;
    public Text playerMoneyLable;
    public Text extraMoneyLable;
    public Image extraMoneyImage;

    private void Start()
    {
        UpdatePlayerMoney();
        extraMoneyLable.gameObject.SetActive(false);
        extraMoneyImage.gameObject.SetActive(false);
    }

    public void UpdatePlayerMoney()
    {
        playerMoneyLable.text = money.ToString();

        if(extraMoney > 0)
        {
            extraMoneyLable.gameObject.SetActive(true);
            extraMoneyImage.gameObject.SetActive(true);
            extraMoneyLable.text = extraMoney.ToString();
        }
        else
        {
            extraMoneyLable.gameObject.SetActive(false);
            extraMoneyImage.gameObject.SetActive(false);
            extraMoneyLable.text = extraMoney.ToString();
        }
    }

    public void RemovePlayerMoney(int cost)
    {
        extraMoney -= cost;

        if(extraMoney < 0)
        {
            money -= Mathf.Abs(extraMoney);
            extraMoney = 0;
        }

        UpdatePlayerMoney();
    }

    public void AddPlayerMoney(int pay)
    {
        money += pay;
        UpdatePlayerMoney();
    }

    public int GetMoney()
    {
        return money + extraMoney;
    }

    public void AddExtraMoney(int pay)
    {
        extraMoney += pay;
        UpdatePlayerMoney();
    }

     public void RemoveExtraMoney()
    {
        extraMoney = 0;
        UpdatePlayerMoney();
    }
}
