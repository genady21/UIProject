using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SaveData
{
    [SerializeField]
    public List<int> PurchasedCompleted;

    public int Money;

    public SaveData()
    {
        PurchasedCompleted = new List<int>();
        Money = 100;
    }
}

public class ShopManager : MonoBehaviour
{
  private ShopLot _lot;
  [SerializeField] private int _currentMoney;
  
  [SerializeField] private Text _currentMoneyText;
  [SerializeField] private ShopLot _pref; 
  
  [SerializeField] private Transform _content;
  [SerializeField] public TextMeshProUGUI _noMoney;
  
  [SerializeField] private List<ShopData> _lots;

  private SaveData _save;
  
  private void Awake()
  {
      string data;
      
      if (PlayerPrefs.HasKey("Save"))
      {
          data = PlayerPrefs.GetString("Save");
          _save = JsonUtility.FromJson<SaveData>(data);
      }
      else
      {
          _save = new SaveData();
      }

      _currentMoney = _save.Money;
  }

  private void Start()
  {
      _currentMoneyText.text = _currentMoney.ToString();
      
      for (int i = 0; i < _lots.Count; i++)
      {
          bool isPurchaseCompete;
          if (_save.PurchasedCompleted.Contains(_lots[i].ID))
          {
              isPurchaseCompete = true;
          }
          else
          {
              isPurchaseCompete = false;
          }
          
          ShopLot newPrefInstance = Instantiate(_pref, _content);
          newPrefInstance.Init(_lots[i],this, isPurchaseCompete);
      }
  }

  public bool TrySpend(int value, int id)
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

      _save.Money = _currentMoney;
      _save.PurchasedCompleted.Add(id);

      string saveJson = JsonUtility.ToJson(_save);
      PlayerPrefs.SetString("Save", saveJson);
      return true;
  }
}
