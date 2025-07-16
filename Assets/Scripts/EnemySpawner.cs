using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemyPrefab;

    public List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

    [SerializeField] private float _minSpawnTime=0.5f;
    [SerializeField] private float _maxSpawnTime = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetNextSpawnTimeRoutine()
    {
        float waitTime = Random.Range(_minSpawnTime,_maxSpawnTime);
        yield return new WaitForSeconds(waitTime);
        SpawnEnemy();
    }
    private void SpawnEnemy()
    { 
        int spawnPointSlot = Random.Range(0, _spawnPoints.Count);

        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.transform.position = _spawnPoints[spawnPointSlot].transform.position;
        enemy.target = _player;
        StartCoroutine(GetNextSpawnTimeRoutine());
    }
}
