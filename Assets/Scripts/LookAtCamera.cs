using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Camera m_Camera;

    private void Awake()
    {
        m_Camera = Camera.main;
    }
    void LateUpdate()
    {
        transform.rotation = m_Camera.transform.rotation;
    }
}
