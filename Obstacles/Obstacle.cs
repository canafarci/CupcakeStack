using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ParticleSystem FX;
    protected Stacker _stacker;
    public static event Action<int> OnEggHitObstacle;

    protected virtual void Awake() => _stacker = FindObjectOfType<Stacker>();
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StackableItem item = other.transform.GetComponent<StackableItem>();
            if (item != null && !item.IsInStack) return;
            else if (item == null && other.gameObject.name != "Player") return;

            OnPlayerEnterObstacle(other, item);
        }
    }

    protected virtual void OnPlayerEnterObstacle(Collider other, StackableItem item)
    {
        if (item == null) { return; }
        if (FX != null)
            PlayFX();

        _stacker.RemoveItemFromStack(item);
        OnEggHitObstacle?.Invoke(item.PositionAtStack);
    }

    protected void PlayFX()
    {
        if (FX.gameObject.activeSelf == false)
            FX.gameObject.SetActive(true);
        else
            FX.Play();
    }
}