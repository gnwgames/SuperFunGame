using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DroneInput))]
public class Drone : MonoBehaviour
{
    [SerializeField] private float forwardForce = 10f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private float panForce = 100f;
    [SerializeField] private float maxForwardVelocity = 10f;
    
    private DroneInput _input;
    private Rigidbody _rb;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<DroneInput>();
    }

    public void Update()
    {
        if (_rb.velocity.magnitude > maxForwardVelocity)
        {
            _rb.velocity = new Vector3(
                _rb.velocity.x, _rb.velocity.y, maxForwardVelocity);
        }
    }

    public void FixedUpdate()
    {
        _rb.AddForce(transform.forward * (forwardForce * Time.deltaTime));
        if (_input.Jump())
        {
            _rb.AddForce(
                transform.up * (jumpForce * Time.deltaTime));
        }
        if (_input.Left() > 0)
        {
            _rb.AddForce(-transform.right * (panForce * Time.deltaTime));
        }
        if (_input.Right() > 0)
        {
            _rb.AddForce(transform.right * (panForce * Time.deltaTime));
        }
    }
}
