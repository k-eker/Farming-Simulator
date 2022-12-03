using DG.Tweening;
using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBehaviour : MonoBehaviour
{
    private Item m_Item;
    public Item HeldItem 
    {
        get
        {
            return m_Item;
        }
        private set {
            m_Item = value;

            string output = null;
            if (m_Item != null)
            {
                output = m_Item.itemData.itemName;
            }
            GameManager.Instance.uiController.SetCarryingText(output);
        }
    }

    private Tween m_HoldTween;
    private Tween m_ReleaseTween;

    public GridMovementController movementController;

    private const float GRAB_DURATION = 0.5f;
    private const float GRAB_Y_OFFSET = 1f;

    private void Start()
    {
        HeldItem = null;
    }

    private void Reset()
    {
        movementController = GetComponentInChildren<GridMovementController>();
    }
    public void Interact()
    {
        IInteractable interactable = movementController.CurrentTile.interactable;

        if (HeldItem != null)
        {
            HeldItem.UseItem(this);
        }
        else if (interactable != null)
        {
            interactable.OnInteract(this);
        }
    }

    public void HoldItem(Item item, bool clearTile = true)
    {
        if (clearTile)
        {
            movementController.CurrentTile.interactable = null;
        }

        item.transform.parent = this.transform;


        if (m_ReleaseTween != null && m_ReleaseTween.IsPlaying())
        {
            m_ReleaseTween.Kill();
        }

        Vector3 targetPos = new Vector3(0, GRAB_Y_OFFSET, 0);
        m_HoldTween = item.transform.DOLocalMove(targetPos, GRAB_DURATION);

        HeldItem = item;
    }

    public void ReleaseItem(bool replaceTile = true)
    {
        if (HeldItem == null)
            return;

        if (replaceTile)
        {
            movementController.CurrentTile.interactable = HeldItem;
        }
        HeldItem.transform.parent = null;

        if (m_HoldTween.IsPlaying())
        {
            m_HoldTween.Kill();
        }

        Vector3 tileWorldPos = TilemapController.Tilemap.CellToWorldPosition(movementController.CurrentTile.cellPosition);
        m_ReleaseTween = HeldItem.transform.DOMove(tileWorldPos, GRAB_DURATION);
        HeldItem = null;
    }

}
