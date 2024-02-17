using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ShopLot : MonoBehaviour, ILoot
{
     private string _name;
     private int _price;
     private ShopManager _shopManager;
     private int _id;
     
    [SerializeField] private TextMeshProUGUI _name1;
    [SerializeField] private TextMeshProUGUI _price1;
    [SerializeField] private Button _buttonBuy;
  
    
    public void Init(ShopData lot, ShopManager shopManager, bool isCompletePurchase)
    {
        _shopManager = shopManager;
        _name  = lot.NameLot;
        
        if (isCompletePurchase)
        {
            CompletBuy();
        }
        else
        {
            _price = lot.Price;
            _price1.text = _price.ToString();
        }
        
        _id = lot.ID;
        _name1.text = _name;
    }

    

    public void Buy()
    {
        bool isCompleteBuy = _shopManager.TrySpend(_price, _id);
        if (isCompleteBuy)
        {
            CompletBuy();
        }
        else
        {
            FailBuy();
        }
    }

    public void CompletBuy()
    {
        _buttonBuy.gameObject.SetActive(false);
        _price1.text = "Purchased";
    }

    public void FailBuy()
    {
       _shopManager._noMoney.text="Not enough money";
        StartCoroutine(CaroutineText());
    }

    private IEnumerator CaroutineText()
    {
        yield return new WaitForSeconds(2);
        _shopManager._noMoney.text="  ";
    }
}
