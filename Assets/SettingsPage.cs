using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPage : Page
{
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
}
