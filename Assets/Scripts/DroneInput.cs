using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class DroneInput : MonoBehaviour
{
    [SerializeField] private bool jump;
    [SerializeField] private float left;
    [SerializeField] private float right;

    public void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }

    public void OnLeft(InputValue value)
    {
        left = value.Get<float>();
    }

    public void OnRight(InputValue value)
    {
        right = value.Get<float>();
    }

    public bool Jump()
    {
        bool val = jump;
        jump = false;
        return val;
    }

    public float Left()
    {
        return left;
    }

    public float Right()
    {
        return right;
    }
}
