using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Lockwood/Item Data", order = 0)]
public class ItemData : ScriptableObject
{
    [Header("Item Properties")]
    public string itemName;
    public Item itemPrefab;
    public int itemValue;
}
