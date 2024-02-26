using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
  
  
  private string[]  _names = new string[18]{"Weapon","Bow","Claw","Dagger","Sceptre","Axe","Wand","Body_Armour","Boots","Gloves","Helmet","Shield","Quiver","Amulet","Belt","Ring","Trinket","Jewel"};
  private string[]  _subNames = new string[18]{"Any","Base","Rune","Bronze","Silver","Golden","Abyss","Iron","Magic","Simple","Diamond","Rare","Unique","Normal","Distorted","Desecrated","Corrupted","Vaal"};
  
  private List<String> _nameItems;
  private int _maxItems = 200;
  
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
      
      for (int i = 0; i < _maxItems; i++)
      {
          bool isPurchaseCompete;
          if (_save.PurchasedCompleted.Contains(i))
          {
              isPurchaseCompete = true;
          }
          else
          {
              isPurchaseCompete = false;
          }
          
          string fullName = _names[Random.Range(0, _names.Length)] + " " + _subNames[Random.Range(0, _subNames.Length)];
          int price = Random.Range(1, 15);
          ShopLot newPrefInstance = Instantiate(_pref, _content);
          
          newPrefInstance.Init(fullName,price,i++,this, isPurchaseCompete);
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
