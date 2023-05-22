using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandMoneyText : MonoBehaviour
{

    TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        GameManager.Instance.ResourceManager.OnMoneyChanged += OnMoneyChange;
    }

    private void OnDisable()
    {
        GameManager.Instance.ResourceManager.OnMoneyChanged -= OnMoneyChange;
    }
    private void OnMoneyChange(int money)
    {
        _text.text = "$" + money.ToString();
    }

}
