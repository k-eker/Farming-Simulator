using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public float GridSize { get; private set; }

    public Tile[,] tiles;

    public Tilemap(int width, int height, float gridSize, Transform root)
    {
        Width = width;
        Height = height;
        GridSize = gridSize;

        InitializeTilemap();
        CreateTileMeshes(root);
    }

    private void InitializeTilemap()
    {
        tiles = new Tile[Width, Height];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                tiles[x, y] = new Tile(x, y);
            }
        }
    }
    private void CreateTileMeshes(Transform root)
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Vector3 position = CellToWorldPosition(tiles[x, y].cellPosition);
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                go.transform.parent = root;
                go.transform.position = position;
                go.transform.localScale = new Vector3(GridSize, GridSize, 1);
                go.transform.rotation = Quaternion.Euler(90,0,0);
                go.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
    }

    public Vector3 CellToWorldPosition(Vector2Int cellPos)
    {
        return new Vector3(cellPos.x * GridSize, 0, cellPos.y * GridSize);
    }
    private Vector2Int WorldToCellPosition(Vector3 worldPos)
    {
        return new Vector2Int((int)(worldPos.x / GridSize), (int)(worldPos.z / GridSize));
    }

    public Tile GetTileAtWorldPos(Vector3 worldPos)
    {
        Vector2Int cellPos = WorldToCellPosition(worldPos);
        if (IsWithinBoundaries(cellPos))
        {
            return tiles[cellPos.x, cellPos.y];
        }
        else
        {
            return null;
        }
    }

    private bool IsWithinBoundaries(Vector2Int cellPos)
    {
        return (cellPos.x >= 0 && cellPos.x < Width) && (cellPos.y >= 0 && cellPos.y < Height);
    }

    #region DEBUG
    public void DrawTilePositions()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                Vector3 worldPos = CellToWorldPosition(tiles[x, y].cellPosition);
                UnityEditor.Handles.Label(worldPos, "(" + x + "," + y + ")");
            }
        }
    }

    public void DrawGrid()
    {
        Vector3 offset = new Vector3(GridSize / 2, 0, GridSize / 2);
        Vector3 startWorldPos = Vector3.zero;
        Vector3 endWorldPos = Vector3.zero;
        Color color = Color.black;

        for (int y = 0; y < Height; y++)
        {
            startWorldPos = CellToWorldPosition(tiles[0, y].cellPosition) - offset;
            endWorldPos = CellToWorldPosition(tiles[Width - 1, y].cellPosition) + new Vector3(GridSize, 0, 0) - offset;

            Debug.DrawLine(startWorldPos, endWorldPos, color, float.MaxValue, true);
        }

        startWorldPos = CellToWorldPosition(tiles[0, Height - 1].cellPosition) + new Vector3(0, 0, GridSize) - offset;
        endWorldPos = startWorldPos + new Vector3(GridSize * Height, 0, 0);

        Debug.DrawLine(startWorldPos, endWorldPos, color, float.MaxValue, true);

        for (int x = 0; x < Width; x++)
        {
            startWorldPos = CellToWorldPosition(tiles[x, 0].cellPosition) - offset;
            endWorldPos = CellToWorldPosition(tiles[x, Height - 1].cellPosition) + new Vector3(0, 0, GridSize) - offset;

            Debug.DrawLine(startWorldPos, endWorldPos, color, float.MaxValue, true);
        }

        startWorldPos = CellToWorldPosition(tiles[Width - 1, 0].cellPosition) + new Vector3(GridSize, 0, 0) - offset;
        endWorldPos = startWorldPos + new Vector3(0, 0, GridSize * Height);

        Debug.DrawLine(startWorldPos, endWorldPos, color, float.MaxValue, true);
    }
    #endregion
}
