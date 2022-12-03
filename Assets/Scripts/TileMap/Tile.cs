using System.Collections;
using UnityEngine;

public class Tile
{
    public Vector2Int cellPosition;
    public IInteractable interactable;

    public Tile(int x, int y)
    {
        cellPosition = new Vector2Int(x, y);
    }

}
