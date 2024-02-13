using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class SettingsPage : Page
{
    [SerializeField] private Image Bg;
    public override void Show()
    {
        base.Show();
        Debug.Log("Open SettingsPage");
    }

    public override void Close()
    {
        base.Close();
        Debug.Log("Close SettingsPage");
    }

    public void ChangeColorBG()
    {
        Bg.color=Color.blue;
    }
}
