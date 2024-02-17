using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPage : Page
{
  
    public override void Show()
    {
        base.Show();
        Debug.Log("Open ShopPage");
        

    }

    public override void Close()
    {
        base.Close();
        Debug.Log("Close ShopPage");
    }

  
}
