using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone2d : MonoBehaviour
{
    [SerializeField] private GameObject drone;
    [SerializeField] private float maxRoll = (Mathf.PI / 2) * Mathf.Rad2Deg;
    [SerializeField] private float maxForwardVelocity = 10f;
    [SerializeField] private float minForwardVelocity = 5f;
    [SerializeField] private float velocityLerpSpeed = 1f;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private float maxPitch = (Mathf.PI / 2.5f) * Mathf.Rad2Deg;
    
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
            _rb.velocity = _rb.velocity.normalized * maxForwardVelocity;
        }
    }

    public void FixedUpdate()
    {
        var minVelocity = Vector3.forward * minForwardVelocity;
        var forwardVelocity = drone.transform.forward * maxForwardVelocity;
        var horizontalVelocity = Vector3.right * (_input.leftStickHoriz * maxForwardVelocity);
        if (_input.rightStickVert > 0 && _input.leftStickHoriz > 0 || _input.rightStickVert > 0 && _input.leftStickHoriz < 0)
        {
            horizontalVelocity *= -1;
        }

        var finalVelocity = minVelocity + forwardVelocity + horizontalVelocity;
        // var finalVelocity = Vector3.Lerp(_rb.velocity, minVelocity + forwardVelocity + horizontalVelocity, velocityLerpSpeed * Time.deltaTime);
        _rb.AddForce(finalVelocity);
        
        
        _roll = maxRoll * _input.leftStickHoriz;
        _pitch = maxPitch * _input.rightStickVert;
        var rollQuat = Quaternion.AngleAxis(_roll, Vector3.back);
        var pitchQuat = Quaternion.AngleAxis(_pitch , Vector3.right);
        drone.transform.rotation = Quaternion.Lerp(drone.transform.rotation, rollQuat * pitchQuat, rotationSpeed * Time.deltaTime);
        // transform.rotation = Quaternion.Lerp(transform.rotation, pitchQuat, rotationSpeed * Time.deltaTime);
    }
}
