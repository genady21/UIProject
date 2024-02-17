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
    [SerializeField] private TextMeshProUGUI _name1;
    [SerializeField] private TextMeshProUGUI _price1;
    
    public void Init(ShopData lot, ShopManager shopManager)
    {
        _shopManager = shopManager;
        _name  = lot.NameLot;
        _price = lot.Price;
        
        _name1.text = _name;
        _price1.text = _price.ToString();
    }

    

    public void Buy()
    {
        bool isCompleteBuy = _shopManager.TrySpend(_price);
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
        
    }

    public void FailBuy()
    {
        
    }
}
