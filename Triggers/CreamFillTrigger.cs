using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreamFillTrigger : ItemSetActiveTrigger
{
    private void Awake() => _cakeStage = CakeStage.CreamFill;

    protected override void TriggerBehaviour(Collider other)
    {
        StackableItemState itemState = other.GetComponent<StackableItemState>();

        if (!itemState.HasDoughFilled || !itemState.HasDoughBaked || itemState.HasCreamFilled)
            return;

        base.TriggerBehaviour(other);

        itemState.HasCreamFilled = true;
        if (other.gameObject.name != "Player")
            other.GetComponent<ITweener>().Tween(CakeStage.CreamFill);

    }
}
