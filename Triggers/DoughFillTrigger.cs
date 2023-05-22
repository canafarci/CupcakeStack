using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughFillTrigger : ItemSetActiveTrigger
{
    private void Awake() => _cakeStage = CakeStage.DoughFill;
    protected override void TriggerBehaviour(Collider other)
    {
        StackableItemState itemState = other.GetComponent<StackableItemState>();
        if (itemState.HasDoughFilled)
            return;

        base.TriggerBehaviour(other);
        itemState.HasDoughFilled = true;
        if (other.gameObject.name != "Player")
            other.GetComponent<ITweener>().Tween(CakeStage.DoughFill);
    }
}