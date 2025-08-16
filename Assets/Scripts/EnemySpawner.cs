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
    [SerializeField] private Enemy_SO _enemyTemplateToSpawn;
    void Start()
    {
        SpawnEnemy();
    }

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
        
        int spawnPointSlot = Random.Range(0, _spawnPoints.Count);//set position

        Enemy enemy = Instantiate(_enemyPrefab);

        if (_enemyTemplateToSpawn != null)
        {
            enemy.enemyTemplate = _enemyTemplateToSpawn;
        }
        enemy.transform.position = _spawnPoints[spawnPointSlot].transform.position;
        enemy.target = _player;
        enemy.unitEventHandler.ResetHealth();
        StartCoroutine(GetNextSpawnTimeRoutine());

    }
}
