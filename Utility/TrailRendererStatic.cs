using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererStatic : MonoBehaviour
{
    TrailRenderer _trailRenderer;
    [SerializeField] float _xOffset;
    InputReader _inputReader;
    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _xOffset = 0.5f;
        _inputReader = FindObjectOfType<InputReader>();
    }

    void Update()
    {
        if (!_inputReader.IsDragging)
        {
            for (int i = 0; i < 40; i++)
            {
                _trailRenderer.AddPosition(transform.position);
            }
        }

        for (int i = 0; i < _trailRenderer.positionCount; i++)
        {
            Vector3 pos = _trailRenderer.GetPosition(i);
            pos.x -= _xOffset;
            _trailRenderer.SetPosition(i, pos);
        }
    }
}
