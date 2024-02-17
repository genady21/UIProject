using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] public class ShopData
{
  [SerializeField] private int _ID;
  [SerializeField] private string _nameLot;

  public string NameLot
  {
    get { return _nameLot; }
  }
  
  [SerializeField] private int _price;
  
  public int Price
  {
    get { return _price; }
  }
}
