using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
  private ShopLot _lot;
  [SerializeField] private int _currentMoney=100;
  
  [SerializeField] private Text _currentMoneyText;
  [SerializeField] private ShopLot _pref; 
  [SerializeField] private Transform _content;
  [SerializeField] private List<ShopData> _lots;

  private void Awake()
  {
      if (PlayerPrefs.HasKey("Money"))
      {
          _currentMoney = PlayerPrefs.GetInt("Money");
      }
      PlayerPrefs.SetInt("Money",_currentMoney);
  }

  private void Start()
  {
      _currentMoneyText.text = _currentMoney.ToString();
      
      for (int i = 0; i < _lots.Count; i++)
      {
          ShopLot newPrefInstance = Instantiate(_pref, _content);
          newPrefInstance.Init(_lots[i],this);
          RectTransform rectTransform = newPrefInstance.GetComponent<RectTransform>();
          rectTransform.anchoredPosition = new Vector2(0, -_content.childCount * rectTransform.rect.height);
          LayoutRebuilder.ForceRebuildLayoutImmediate(_content.GetComponent<RectTransform>());
      }
  }

  public bool TrySpend(int value)
  {
      if (_currentMoney < value)
      {
          return false;
      }
      _currentMoney -= value;
      _currentMoneyText.text = _currentMoney.ToString();
      
      if (_currentMoney != PlayerPrefs.GetInt("Money"))
      {
          PlayerPrefs.SetInt("Money",_currentMoney);
      }
      
      return true;
  }
}
