using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<Obstacle> obstacles;
    [SerializeField] private float spawnInterval = 3.0f;
    [SerializeField] private float startVelocity;
    
    private float _timeToSpawn = 0.0f;
    private float _zVelocity = 3.0f;

    public void Awake()
    {
        _zVelocity = startVelocity;
    }

    public void Update()
    {
        _timeToSpawn -= Time.deltaTime;
        if (_timeToSpawn < 0)
        {
            _timeToSpawn = spawnInterval;
            int i = Random.Range(0, obstacles.Count);
            Obstacle obstacle = obstacles[i];
            obstacle.Spawn(transform.position);
        }
    }
}
