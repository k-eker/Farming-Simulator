using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Item
{
    [SerializeField] private GameObject m_ModelObject;
    [SerializeField] private GameObject m_BushModelObject;

    private Tile m_PlantedTile;

    private void Reset()
    {
        m_ModelObject = GetComponentInChildren<MeshRenderer>().gameObject;
    }

    public override void UseItem(InteractionBehaviour interactionBehaviour)
    {
        base.UseItem(interactionBehaviour);

        if (interactionBehaviour.movementController.CurrentTile.interactable == null)
        {
            m_PlantedTile = interactionBehaviour.movementController.CurrentTile;
            m_PlantedTile.interactable = this;
            PlantSeed();
            interactionBehaviour.ReleaseItem();
        }
    }

    private void PlantSeed()
    {
        canBeInteracted = false;

        Vector3 position = TilemapController.Tilemap.CellToWorldPosition(m_PlantedTile.cellPosition);
        ProcessedItemData processedIemData = itemData as ProcessedItemData;
        Timer timer = new Timer(processedIemData.processingTime, position, this, OnTimerTick, OnTimerComplete);

        m_ModelObject.SetActive(false);
        m_BushModelObject.SetActive(true);
        m_BushModelObject.transform.localScale = Vector3.zero;
    }

    private void OnTimerTick(Timer timer)
    {
        float scale = timer.CompletionValue;
        m_BushModelObject.transform.localScale = new Vector3(scale , scale, scale);
    }

    private void OnTimerComplete()
    {
        ProcessedItemData processedIemData = itemData as ProcessedItemData;
        Vector3 position = TilemapController.Tilemap.CellToWorldPosition(m_PlantedTile.cellPosition);
        Item harvest = Instantiate(processedIemData.product, position, Quaternion.identity);
        m_PlantedTile.interactable = harvest;

        Destroy(this.gameObject);
    }
}
