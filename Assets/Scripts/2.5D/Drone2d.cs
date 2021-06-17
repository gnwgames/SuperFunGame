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
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float lookSpeed = 1f;
    [SerializeField] private float maxPitch = (Mathf.PI / 2.5f) * Mathf.Rad2Deg;
    
    private DroneInput _input;
    private Rigidbody _rb;

    private float _roll;
    private float _pitch;
    private Quaternion _targetRot;

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
        var minVelocity = transform.forward * minForwardVelocity;
        var forwardVelocity = drone.transform.forward * maxForwardVelocity;
        var horizontalVelocity = transform.right * (_input.leftStickHoriz  * maxForwardVelocity);
        if (_input.rightStickVert > 0 && _input.leftStickHoriz > 0 || _input.rightStickVert > 0 && _input.leftStickHoriz < 0)
        {
            horizontalVelocity *= -1;
        }

        var finalVelocity = minVelocity + forwardVelocity + horizontalVelocity;
        // var finalVelocity = Vector3.Lerp(_rb.velocity, minVelocity + forwardVelocity + horizontalVelocity, velocityLerpSpeed * Time.deltaTime);
        _rb.AddForce(finalVelocity);
        
        
        _roll = maxRoll * _input.leftStickHoriz;
        _pitch = maxPitch * _input.rightStickVert * Mathf.Abs(_input.leftStickHoriz);
        var rollQuat = Quaternion.AngleAxis(_roll, -Vector3.forward);
        var pitchQuat = Quaternion.AngleAxis(_pitch , Vector3.right);
        drone.transform.localRotation = Quaternion.Lerp(drone.transform.localRotation, rollQuat * pitchQuat, rotationSpeed * Time.deltaTime);

        var rot = _pitch;
        if (_input.rightStickVert < 0 && _input.leftStickHoriz > 0 || _input.rightStickVert > 0 && _input.leftStickHoriz > 0)
        {
            rot *= -1;
        }

        var rotQuat = Quaternion.AngleAxis(transform.rotation.eulerAngles.y + rot, transform.up);
        var lerpedRot = Quaternion.Lerp(transform.rotation, rotQuat, lookSpeed * Time.deltaTime);
        lerpedRot.x = 0;
        lerpedRot.z = 0;
        _targetRot = lerpedRot;
    }
}
