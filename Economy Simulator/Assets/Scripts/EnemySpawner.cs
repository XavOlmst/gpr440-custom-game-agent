using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Enemy spawnEnemy;
    [SerializeField] private float spawnRadius;
    [SerializeField] private Vector2 spawnDelayRange;
    private float _spawnTimer;
    
    private void Start()
    {
        _spawnTimer = Random.Range(spawnDelayRange.x, spawnDelayRange.y);
    }

    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) > 15)
            return; //early out if player is too far
        
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer < 0)
        {
            Vector2 spawnPosition = Random.insideUnitCircle.normalized * Random.Range(0, Mathf.Abs(spawnRadius));

            Instantiate(spawnEnemy, spawnPosition, Quaternion.identity);

            _spawnTimer = Random.Range(spawnDelayRange.x, spawnDelayRange.y);
        }
    }
}
