using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField]private float _moveSpeed;
    private float horizontal, vertical;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(horizontal, 0, vertical);

        _rb.AddForce(vec * _moveSpeed);
    }
}
