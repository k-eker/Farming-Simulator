using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Left, Right, Up, Down }
public class GridMovementController : MonoBehaviour
{
    private Tile m_CurrentTile;
    public Tile CurrentTile {
        get { return m_CurrentTile; }
        private set {
            m_CurrentTile = value;
            GameManager.Instance.uiController.SetVisitingText(CurrentTile.interactable as Structure);
        }
    }

    private Tween m_MovementTween;

    [SerializeField] private float m_MovementDuration = 0.3f;
    [SerializeField] private float m_JumpPower = 0.5f;

    private void Start()
    {
        CurrentTile = TilemapController.Tilemap.GetTileAtWorldPos(transform.position);
    }


    public void Move(Direction direction)
    {
        if (m_MovementTween != null && m_MovementTween.IsPlaying())
            return;

        Vector3 targetPos = DirectionToPosition(direction);
        Tile nextTile = TilemapController.Tilemap.GetTileAtWorldPos(targetPos);
        if (nextTile != null)
        {
            CurrentTile = nextTile;
            m_MovementTween = transform.DOJump(targetPos, m_JumpPower, 1, m_MovementDuration);
        }
    }


    private Vector3 DirectionToPosition(Direction direction)
    {
        Vector3 result = transform.position;
        float gridSize = TilemapController.Tilemap.GridSize;

        switch (direction)
        {
            case Direction.Left:
                result += new Vector3(-gridSize, 0, 0);
                break;
            case Direction.Right:
                result += new Vector3(gridSize, 0, 0);
                break;
            case Direction.Up:
                result += new Vector3(0, 0, gridSize);
                break;
            case Direction.Down:
                result += new Vector3(0, 0, -gridSize);
                break;
        }
        return result;
    }
}
