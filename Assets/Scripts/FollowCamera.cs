using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 followOffset;
    [SerializeField] private Vector3 lookOffset;
    [SerializeField] private GameObject target;

    public void Start()
    {
        transform.position = target.transform.position + followOffset;
        transform.LookAt(target.transform.position + lookOffset);
    }

    public void Update()
    {
        var targetPos = target.transform.position + followOffset;
        // transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed);
        // transform.LookAt();
    }
}
