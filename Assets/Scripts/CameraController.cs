using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    private Vector3 offset;
    private Vector3 targetPosition;

    private void Start() 
    {
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate() 
    {
        transform.position = target.transform.position + offset;
    }
}

