using System;
using UnityEngine;

[Serializable]
public abstract class Page : MonoBehaviour, IUIPage
{
    public virtual void Show()
    {
       gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnClickBtnClose()
    {
        UIManager.I.BackToMenu();
    }
}
