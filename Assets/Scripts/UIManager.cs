using System;
using System.Collections.Generic;
using UnityEngine;

public enum PageType
{
    Shop,
    Game,
    Settings,
    MainMenu,
}

[Serializable]
public class PageData
{
    public PageType PageType;
    public Page Page;
}

public class UIManager : MonoBehaviour
{
    public static UIManager I;
    
    [SerializeField] private List<PageData> _allPage;
    
    private Page _currentPage;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        
        OpenPage(PageType.MainMenu);
    }

    public void CloseCurrent()
    {
        if (_currentPage != null)
        {
            _currentPage.Close();
        }
    }

    public void BackToMenu()
    {
        OpenPage(PageType.MainMenu);
    }
    
    public void OpenPage(PageType pageType)
    {
        CloseCurrent();
        foreach (var pageData in _allPage)
        {
            if (pageData.PageType == pageType)
            {
                _currentPage = pageData.Page;
                _currentPage.Show();
            }
        }
    }
}
