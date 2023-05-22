using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Stacker : MonoBehaviour
{
    public List<StackableItem> ItemList { get { return _itemList; } }

    List<StackableItem> _itemList = new List<StackableItem>();
    public event Action<List<StackableItem>, bool> OnStackListChanged;

    public int AddItemToStack(StackableItem ball)
    {
        _itemList.Add(ball);

        OnStackListChanged.Invoke(_itemList, true);
        _itemList = _itemList.Distinct().ToList();
        return _itemList.IndexOf(ball);
    }

    public void RemoveItemFromStack(StackableItem item)
    {
        if (item == null) { return; }
        int hitIndex = item.PositionAtStack;

        for (int i = _itemList.Count - 1; i >= 0; i--)
        {
            if (hitIndex <= i)
            {
                _itemList.RemoveAt(i);
            }
        }
        Destroy(item.transform.gameObject);
        OnStackListChanged.Invoke(_itemList, false);
    }

    public void RemoveItemFromStackWithoutDestroying(StackableItem item)
    {
        _itemList.Remove(item);
        OnStackListChanged.Invoke(_itemList, false);
    }
}
