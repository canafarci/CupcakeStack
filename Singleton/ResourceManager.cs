using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    static int _currentMoney;

    public event Action<int> OnMoneyChanged;

    private void Start()
    {
        //? FOR SAVING
        //_currentMoney = PlayerPrefs.GetInt(PrefKeys.Money);
        _currentMoney = 0;
    }
    public void OnMoneyChange(int changeAmount)
    {
        _currentMoney += changeAmount;
        //? FOR SAVING        
        //PlayerPrefs.SetInt(PrefKeys.Money, _currentMoney);
        OnMoneyChanged(_currentMoney);
    }
}
