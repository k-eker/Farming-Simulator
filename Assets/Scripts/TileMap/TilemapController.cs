using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapController : MonoBehaviour
{
    [Header("DEBUG")]
    [SerializeField] private bool m_ShowTilePositions = false;
    [SerializeField] private bool m_ShowGrid = false;
    [Header("Properties")]
    [SerializeField] [Range(1, 512)] private int m_Width = 64;
    [SerializeField] [Range(1, 512)] private int m_Height = 64;
    [SerializeField]  private float m_GridSize = 1f;

    public static Tilemap Tilemap { get; private set; }

    private void Start()
    {
        Tilemap = new Tilemap(m_Width, m_Height, m_GridSize, transform);

        if (m_ShowGrid)
        {
            Tilemap.DrawGrid();
        }
    }

   

    private void OnDrawGizmos()
    {
        if (Application.isPlaying && m_ShowTilePositions)
        {
            Tilemap.DrawTilePositions();
        } 
    }
}
