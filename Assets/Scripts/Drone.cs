using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DroneInput))]
public class Drone : MonoBehaviour
{
    [SerializeField] private GameObject drone;
    [SerializeField] private float rollPct = 1.0f;
    [SerializeField] private float maxForwardVelocity = 10f;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private float maxPitch = (Mathf.PI / 2) * Mathf.Rad2Deg;
    
    private DroneInput _input;
    private Rigidbody _rb;

    private float _roll;
    private float _pitch;

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
        _rb.velocity = Vector3.forward * maxForwardVelocity;

        _pitch = maxPitch * _input.rightStickVert;
        _roll = Mathf.Atan2(_input.leftStickHoriz, _input.leftStickVert) * Mathf.Rad2Deg;
        var rollQuat = Quaternion.AngleAxis(_roll * new Vector2(_input.leftStickHoriz, _input.leftStickVert).magnitude , Vector3.back);
        var pitchQuat = Quaternion.AngleAxis(_pitch , Vector3.right);
        drone.transform.rotation = Quaternion.Lerp(drone.transform.rotation, rollQuat * pitchQuat, rotationSpeed * Time.deltaTime);

    }
    
}
