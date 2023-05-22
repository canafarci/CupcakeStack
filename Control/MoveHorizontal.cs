using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveHorizontal : MonoBehaviour
{
    [SerializeField] float _smoothingFactor, _xBounds = 5.71f;
    [SerializeField] Transform _handTransform;
    InputReader _inputReader;
    bool _controlRemoved = false;
    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _smoothingFactor = 6f;
    }

    private void Update()
    {
        if (_controlRemoved) return;

        Vector3 localPos = transform.localPosition;
        localPos.z -= _inputReader.XChange;
        localPos.z = Mathf.Clamp(localPos.z, -_xBounds, _xBounds);

        Vector3 lerpedPos = Vector3.Lerp(transform.localPosition, localPos, _smoothingFactor);
        transform.localPosition = lerpedPos;

        Vector3 handPos = _handTransform.localPosition;
        handPos.z = lerpedPos.z;
        _handTransform.localPosition = handPos;
    }

    public void RemoveControl() => _controlRemoved = true;
    public void EnableControl() => _controlRemoved = false;
    public void CenterPosition()
    {
        transform.DOLocalMoveZ(0, .5f);
        _handTransform.DOLocalMoveZ(0, .5f);
    }
}