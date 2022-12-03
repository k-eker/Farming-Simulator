using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour, IInteractable
{
    protected Tile currentTile;
    private void Start()
    {
        currentTile = TilemapController.Tilemap.GetTileAtWorldPos(transform.position);
    }
    public virtual void OnInteract(InteractionBehaviour interactionBehaviour)
    {
        
    }
}
