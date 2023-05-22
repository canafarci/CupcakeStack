using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PunchScaleTrigger : MonoBehaviour
{
    [SerializeField] string _tag;
    float _factor = 1.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tag))
        {
            Vector3 scale = transform.localScale;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(scale * _factor, .25f));
            sequence.Append(transform.DOScale(scale, .25f));
        }
    }
}
