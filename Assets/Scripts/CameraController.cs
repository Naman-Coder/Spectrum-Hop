using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    private Vector3 offset = new (0f, 3f, -5f);

    [Range(0, 1)]
    public float followSpeed = 0.1f;  

    private Vector3 targetPosition;

    private void LateUpdate()
    {
        targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
        
    }
}

