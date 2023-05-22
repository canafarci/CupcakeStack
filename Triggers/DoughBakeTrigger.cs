using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughBakeTrigger : ItemSetActiveTrigger
{
    private void Awake() => _cakeStage = CakeStage.DoughBake;

    protected override void TriggerBehaviour(Collider other)
    {
        StackableItemState itemState = other.GetComponent<StackableItemState>();

        if (!itemState.HasDoughFilled || itemState.HasDoughBaked)
            return;

        base.TriggerBehaviour(other);
        itemState.HasDoughBaked = true;
        other.GetComponent<ITweener>().Tween(CakeStage.DoughBake);
    }
}
