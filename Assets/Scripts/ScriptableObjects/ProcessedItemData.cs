using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Processed Item Data", menuName = "Lockwood/Processed Item Data", order = 0)]
public class ProcessedItemData : ItemData
{
    [Header("Processed Item Properties")]
    [Tooltip("In seconds")]
    public int processingTime;
    public Item product;
}
