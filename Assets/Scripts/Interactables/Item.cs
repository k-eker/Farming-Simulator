using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour, IInteractable
{
    public ItemData itemData;
    public int amount;
    public UnityEvent onInteract;
    protected bool canBeInteracted = true;

    public virtual void OnInteract(InteractionBehaviour interactionBehaviour)
    {
        if (!canBeInteracted)
            return;

        if (amount > 1)
        {
            amount--;
            Item clone = Instantiate(this, transform.position, transform.rotation);
            clone.amount = 1;
            interactionBehaviour.HoldItem(clone, false);
        }
        else
        {
            interactionBehaviour.HoldItem(this);
        }

        onInteract.Invoke();
    }

    public virtual void UseItem(InteractionBehaviour interactionBehaviour)
    {

    }
}
