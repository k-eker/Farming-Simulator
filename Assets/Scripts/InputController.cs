using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [Header("Key Bindings")]
    [SerializeField] private KeyCode m_UpKey = KeyCode.W;
    [SerializeField] private KeyCode m_LeftKey = KeyCode.A;
    [SerializeField] private KeyCode m_DownKey = KeyCode.S;
    [SerializeField] private KeyCode m_RightKey = KeyCode.D;
    [Space(30)]
    [SerializeField] private KeyCode m_InteractKey = KeyCode.E;

    [Header("References")]
    [SerializeField] private GridMovementController m_MovementController;
    [SerializeField] private InteractionBehaviour m_InteractionBehaviour;

    private void Reset()
    {
        m_MovementController = GetComponentInChildren<GridMovementController>();
        m_InteractionBehaviour = GetComponentInChildren<InteractionBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKey(m_UpKey))
        {
            m_MovementController.Move(Direction.Up);
        }
        else if (Input.GetKey(m_DownKey))
        {
            m_MovementController.Move(Direction.Down);
        }
        else if (Input.GetKey(m_LeftKey))
        {
            m_MovementController.Move(Direction.Left);
        }
        else if (Input.GetKey(m_RightKey))
        {
            m_MovementController.Move(Direction.Right);
        }
        
        if (Input.GetKeyDown(m_InteractKey))
        {
            m_InteractionBehaviour.Interact();
        }
    }
}
