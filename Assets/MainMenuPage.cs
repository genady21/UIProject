using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPage : Page
{
    public override void Show()
    {
        base.Show();
        Debug.Log("Open MainMenuPage");
    }

    public override void Close()
    {
        base.Close();
        Debug.Log("Close MainMenuPage");
    }

    public void OpenShop()
    {
        UIManager.I.OpenPage(PageType.Shop);
    }
    
    public void OpenSettings()
    {
        UIManager.I.OpenPage(PageType.Settings);
    }
    public void OpenGame()
    {
        UIManager.I.OpenPage(PageType.Game);
    }
}
