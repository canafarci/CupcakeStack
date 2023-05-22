using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackMover : MonoBehaviour
{
    List<StackableItem> _itemList;
    [SerializeField] float _smoothingFactor, _stackForwardSpacing;
    Transform _playerItemTransform;
    Stacker _stacker;
    bool _paused, _sideTracked = false;

    private void Awake()
    {
        _playerItemTransform = transform;
        _itemList = new List<StackableItem>();
        _stacker = GetComponent<Stacker>();
    }

    private void OnEnable() => _stacker.OnStackListChanged += OnBallListChanged;
    private void OnDisable() => _stacker.OnStackListChanged -= OnBallListChanged;

    private void Update()
    {
        if (_paused) return;
        if (_itemList.Count <= 0) return;

        if (_sideTracked)
        {
            SideStackMove();
        }
        else
        {
            StackMove();
        }

    }

    private void StackMove()
    {
        for (int i = 0; i < _itemList.Count; i++)
        {
            if (i == 0)
            {
                _itemList[i].transform.localPosition = Vector3.Lerp(_itemList[i].transform.localPosition,
                new Vector3(_playerItemTransform.localPosition.x + _stackForwardSpacing, _playerItemTransform.localPosition.y, _playerItemTransform.localPosition.z),
                _smoothingFactor * Time.smoothDeltaTime);
            }
            else
            {
                _itemList[i].transform.localPosition = Vector3.Lerp(_itemList[i].transform.localPosition,
                new Vector3(_playerItemTransform.localPosition.x + ((_itemList[i].PositionAtStack + 1) * _stackForwardSpacing), _playerItemTransform.localPosition.y, _itemList[i - 1].transform.localPosition.z),
                _smoothingFactor * Time.smoothDeltaTime);
            }
        }
    }

    private void SideStackMove()
    {
        for (int i = 0; i < _itemList.Count; i++)
        {
            _itemList[i].transform.localPosition = Vector3.Lerp(_itemList[i].transform.localPosition,
                new Vector3(_playerItemTransform.localPosition.x + ((i + 1) * _stackForwardSpacing), _itemList[i].transform.localPosition.y, _itemList[i].transform.localPosition.z),
                _smoothingFactor * Time.smoothDeltaTime);
        }
    }

    private void OnBallListChanged(List<StackableItem> list, bool addedToList) => _itemList = list;
    public void EmptyStack() => _itemList.Clear();
    public void PauseStacker() => _paused = true;
    public void ResumeNormalMovement() => _paused = false;
    public void AlternativeMove() => _sideTracked = true;
    public void NormalizeMove() => _sideTracked = false;
}

