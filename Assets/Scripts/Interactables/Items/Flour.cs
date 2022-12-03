using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flour : Item
{
    public override void UseItem(InteractionBehaviour interactionBehaviour)
    {
        base.UseItem(interactionBehaviour);

        if (interactionBehaviour.movementController.CurrentTile.interactable is Grocer)
        {
            canBeInteracted = false;
            Grocer grocer = interactionBehaviour.movementController.CurrentTile.interactable as Grocer;
            interactionBehaviour.ReleaseItem(false);
            grocer.SellItem(this);
        }
        else if (interactionBehaviour.movementController.CurrentTile.interactable == null)
        {
            interactionBehaviour.ReleaseItem();
        }

    }
}
