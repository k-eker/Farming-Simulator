using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    private void Start()
    {
        Camera.main.GetComponent<CameraFollow>().Target = this.transform;
    }
}
