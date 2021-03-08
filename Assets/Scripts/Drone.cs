using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private float zVelocity = 10f;

    private Rigidbody _rb;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        _rb.velocity = new Vector3(
            _rb.velocity.x, _rb.velocity.y, zVelocity);
    }
}
