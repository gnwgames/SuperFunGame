using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class DroneInput : MonoBehaviour
{
    [SerializeField] public float leftStickVert;
    [SerializeField] public float leftStickHoriz;
    [SerializeField] public float rightStickHoriz;
    [SerializeField] public float rightStickVert;
    
    public void OnLeftStickVert(InputValue value)
    {
        leftStickVert = value.Get<float>();
    }

    public void OnLeftStickHoriz(InputValue value)
    {
        leftStickHoriz = value.Get<float>();
    }

    public void OnRightStickVert(InputValue value)
    {
        rightStickVert = value.Get<float>();
    }
    
    public void OnRightStickHoriz(InputValue value)
    {
        rightStickHoriz = value.Get<float>();
    }
}
