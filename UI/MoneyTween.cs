using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoneyTween : MonoBehaviour, ITweener
{
    public void Tween()
    {
        Sequence sequence = DOTween.Sequence();

        Vector3 _baseScale = transform.localScale;

        sequence.Append(transform.DOScale(_baseScale * 1.1f, .2f)).
        Append(transform.DOScale(_baseScale, .2f));
    }

    public void Tween(CakeStage cakeStage)
    {
        throw new System.NotImplementedException();
    }
}
