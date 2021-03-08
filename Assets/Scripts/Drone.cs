using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DroneInput))]
public class Drone : MonoBehaviour
{
    [SerializeField] private float zVelocity = 10f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private float horizontalForce = 100f;
    
    private DroneInput _input;
    private Rigidbody _rb;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<DroneInput>();
    }

    public void Update()
    {
        _rb.velocity = new Vector3(
            _rb.velocity.x, _rb.velocity.y, zVelocity);
    }

    public void FixedUpdate()
    {
        if (_input.Jump())
        {
            _rb.AddForce(
                transform.up * (jumpForce * Time.deltaTime));
        }
        if (_input.Left() > 0)
        {
            _rb.AddForce(-transform.right * (horizontalForce * Time.deltaTime));
        }
        if (_input.Right() > 0)
        {
            _rb.AddForce(transform.right * (horizontalForce * Time.deltaTime));
        }
    }
}
