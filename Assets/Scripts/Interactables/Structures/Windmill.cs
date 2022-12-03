using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : Structure
{
    public Item ProcessingItem { get; private set; }
    private Item m_Product;
    public void ProcessItem(Item item)
    {
        ProcessingItem = item;
        ProcessedItemData processedIemData = item.itemData as ProcessedItemData;
        Timer timer = new Timer(processedIemData.processingTime, transform.position, this, null, OnTimerComplete);
    }

    private void OnTimerComplete()
    {
        ProcessedItemData processedIemData = ProcessingItem.itemData as ProcessedItemData;
        m_Product = Instantiate(processedIemData.product, transform.position, Quaternion.identity);

        currentTile.interactable = m_Product;
        m_Product.onInteract.AddListener(OnProductCollected);
        Destroy(ProcessingItem.gameObject);
    }

    private void OnProductCollected()
    {
        m_Product.onInteract.RemoveListener(OnProductCollected);
        ProcessingItem = null;
        currentTile.interactable = this;
    }
}
