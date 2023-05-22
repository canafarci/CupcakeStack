using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinkleShakeTrigger : ItemSetActiveTrigger
{
    private void Awake() => _cakeStage = CakeStage.SprinkleShake;

    protected override void TriggerBehaviour(Collider other)
    {
        StackableItemState itemState = other.GetComponent<StackableItemState>();

        if (!itemState.HasDoughFilled || !itemState.HasDoughBaked || !itemState.HasCreamFilled || itemState.HasSprinkles)
            return;

        base.TriggerBehaviour(other);

        itemState.HasSprinkles = true;
        if (other.gameObject.name != "Player")
            other.GetComponent<ITweener>().Tween(CakeStage.SprinkleShake);
    }
}