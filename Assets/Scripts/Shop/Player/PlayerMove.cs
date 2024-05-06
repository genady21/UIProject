using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    

    private float vInput;
    private float hInput;

    private Rigidbody _rb;

    private CapsuleCollider _col;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _rb.useGravity = true;
        
    }
    private void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
    }
    
    private void FixedUpdate()
    {
        var rotation = Vector3.up * hInput;
        var angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }
}
