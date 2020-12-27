using UnityEngine;
using System.Collections;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothFactor = 0.5f;

    private Vector3 initialPosition;
    private Vector3 offset;

    private void Awake()
    {
        initialPosition = transform.position;
        offset = target.position - transform.position;
    }

    void FixedUpdate()
    {
        if (target.position.y < 0)
            return;
            
        transform.position = Vector3.Slerp(transform.position, target.position - offset, smoothFactor);
    }
}