using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPage : Page
{
    [SerializeField] private Text _currency;
    public override void Show()
    {
        base.Show();
        Debug.Log("Open ShopPage");
        _currency.text = "20";

    }

    public override void Close()
    {
        base.Close();
        Debug.Log("Close ShopPage");
    }

    public void Buy()
    {
        _currency.text = "0";
    }
}
