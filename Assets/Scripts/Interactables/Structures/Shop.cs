using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Structure
{
    [SerializeField] private ItemData m_AvailableItem;
    public override void OnInteract(InteractionBehaviour interactionBehaviour)
    {
        base.OnInteract(interactionBehaviour);
        TryBuyItem(interactionBehaviour);
    }

    private void TryBuyItem(InteractionBehaviour interactionBehaviour)
    {
        if (interactionBehaviour.HeldItem != null)
            return;

        Player player = GameManager.Instance.player;

        if (player.CompareValues(m_AvailableItem.itemValue))
        {
            GameManager.Instance.uiController.CreateFloatingText(transform.position).SetText(-m_AvailableItem.itemValue + " Coins");
            player.Coins -= m_AvailableItem.itemValue;
            Item item = Instantiate(m_AvailableItem.itemPrefab, transform.position, Quaternion.identity);
            interactionBehaviour.HoldItem(item, false);
        }
    }

}
