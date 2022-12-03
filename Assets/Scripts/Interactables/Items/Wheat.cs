using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : Item
{
    public override void UseItem(InteractionBehaviour interactionBehaviour)
    {
        base.UseItem(interactionBehaviour);

        if (interactionBehaviour.movementController.CurrentTile.interactable is Windmill)
        {
            Windmill windmill = interactionBehaviour.movementController.CurrentTile.interactable as Windmill;
            if (windmill.ProcessingItem == null)
            {
                windmill.ProcessItem(this);
                interactionBehaviour.ReleaseItem(false);
                canBeInteracted = false;
            }
        }
        else if (interactionBehaviour.movementController.CurrentTile.interactable == null)
        {
            interactionBehaviour.ReleaseItem();
        }

    }
}
