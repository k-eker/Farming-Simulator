using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grocer : Structure
{
    public void SellItem(Item item)
    {
        GameManager.Instance.uiController.CreateFloatingText(transform.position).SetText("+" + item.itemData.itemValue + " Coins");
        GameManager.Instance.player.Coins += item.itemData.itemValue;
        Destroy(item.gameObject);
    }
}
