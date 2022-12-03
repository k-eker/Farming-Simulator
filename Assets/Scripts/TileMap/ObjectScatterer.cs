using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ScatterObject
{
    public GameObject objectPrefab;
    public int spawnAmount;
}
public class ObjectScatterer : MonoBehaviour
{
    [SerializeField] private ScatterObject[] scatterObjects;

    private void Start()
    {
        ScatterObjects(scatterObjects);
    }
    private void ScatterObjects(ScatterObject[] scatterObjects)
    {
        Tilemap tilemap = TilemapController.Tilemap;

        //store all tiles in a list
        List<Tile> allTiles = new List<Tile>();
        for (int y = 0; y < tilemap.Height; y++)
        {
            for (int x = 0; x < tilemap.Width; x++)
            {
                Tile tile = tilemap.tiles[x, y];
                allTiles.Add(tile);
            }
        }

        //find random tiles
        for (int i = 0; i < scatterObjects.Length; i++)
        {
            for (int j = 0; j < scatterObjects[i].spawnAmount; j++)
            {
                int rand = Random.Range(0, allTiles.Count);
                Tile tile = allTiles[rand];
                allTiles.RemoveAt(rand);
                Vector3 pos = TilemapController.Tilemap.CellToWorldPosition(tile.cellPosition);
                GameObject go = Instantiate(scatterObjects[i].objectPrefab, pos, Quaternion.identity);
                tile.interactable = go.GetComponent<IInteractable>();
            }
        }
    }
}
