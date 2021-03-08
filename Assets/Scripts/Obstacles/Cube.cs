using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Obstacle
{
    public override void Spawn(Vector3 position)
    {
        GameObject instance = Instantiate(
            gameObject,
            position + transform.position,
            transform.rotation);
    }
}
