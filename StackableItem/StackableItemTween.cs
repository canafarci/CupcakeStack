using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class StackableItemTween : MonoBehaviour, ITweener
{
    Vector3 _baseScale, _baseRotation;

    private void Awake()
    {
        _baseScale = transform.localScale;
        _baseRotation = transform.localRotation.eulerAngles;
    }

    public void Tween() => throw new System.NotImplementedException();
    public void Tween(CakeStage cakeStage)
    {
        switch (cakeStage)
        {
            case (CakeStage.DoughFill):
                DoughFillTween();
                break;
            case (CakeStage.DoughBake):
                DoughBakeTween();
                break;
            case (CakeStage.CreamFill):
                CreamFillTween();
                break;
            case (CakeStage.SprinkleShake):
                SprinkleShakeTween();
                break;

            default:
                break;
        }
    }

    private void SprinkleShakeTween()
    {
        Sequence sequence = DOTween.Sequence();

        Vector3 basePosition = transform.localPosition;

        sequence.Append(transform.DOLocalMoveY(basePosition.y + 1f, .2f)).
        Append(transform.DOPunchRotation(_baseRotation + new Vector3(45f, 120f, 15f), .2f, 2)).
        Append(transform.DOLocalMoveY(basePosition.y, .15f));
    }

    private void CreamFillTween()
    {
        transform.DOShakePosition(1f, new Vector3(1f, 0f, 1f), 4, 45f);
    }

    private void DoughBakeTween()
    {
        transform.DOPunchRotation(_baseRotation + new Vector3(30f, 180f, 30f), 1f, 2);
    }

    private void DoughFillTween()
    {
    }
}

/* 
Queue<Sequence> _sequenceStack = new Queue<Sequence>();

    private void Start()
    {
        StartCoroutine(EmptyStack());
    }

    public void TweenY(float value, float duration)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.GetChild(0).DOLocalMoveY(value, duration));
        sequence.Append(transform.GetChild(0).DOLocalMoveY(0f, duration));

        sequence.Pause();
        _sequenceStack.Enqueue(sequence);
    }

    public void TweenZY(float valueZ, float valueY, float durationZ, float durationY)
    {
        Sequence sequence1 = DOTween.Sequence();
        Sequence sequence2 = DOTween.Sequence();

        sequence1.Append(transform.DOLocalMoveZ(valueZ, durationZ));
        sequence2.Append(transform.GetChild(0).DOLocalMoveY(valueY, durationY));

        sequence1.Pause();
        sequence2.Pause();

        _sequenceStack.Enqueue(sequence1);
        _sequenceStack.Enqueue(sequence2);
    }

    public void ResetY()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.GetChild(0).DOLocalMoveY(0, .1f));

        sequence.Pause();
        _sequenceStack.Enqueue(sequence);
    }

    public void DownScale()
    {
        Sequence sequence = DOTween.Sequence();
        Vector3 currentScale = transform.localScale;

        sequence.Append(transform.DOScale(currentScale * 0.9f, 0.05f));

        Vector3 pos = transform.position;
        pos.y = 0.85f * transform.localScale.y;
        sequence.Append(transform.DOLocalMoveY(pos.y, 0.05f));

        sequence.Pause();
        _sequenceStack.Enqueue(sequence);
    }

    IEnumerator EmptyStack()
    {
        while (true)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            while (_sequenceStack.Count > 0)
            {
                Sequence sequence = _sequenceStack.Dequeue();
                sequence.Play();
                yield return sequence.WaitForCompletion();
            }
        }
    }
 */
