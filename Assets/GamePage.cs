using UnityEngine;

public class GamePage : Page
{
    public override void Show()
    {
        base.Show();
        Debug.Log("Open GamePage");
    }

    public override void Close()
    {
        base.Close();
        Debug.Log("Close GamePage");
    }
}
