using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Range(0, 20)] [SerializeField] private float m_SmoothSpeed = 10f;

    private Vector3 m_Offset;

    public Transform Target { private get; set; }

    private void Awake()
    {
        m_Offset = transform.position;
    }

    private void Update()
    {
        Vector3 desiredPos = Target.position + m_Offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, m_SmoothSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }
}
