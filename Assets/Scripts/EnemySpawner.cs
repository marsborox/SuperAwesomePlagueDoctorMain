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
    public Coroutine spawnRoutine;
    public GameManager gameManager;
    void Start()
    {
        //SpawnEnemy();
    }

    void Update()
    {
        //SpawnEnemies();
    }
    private void SpawnEnemies()
    {
        if (spawnRoutine == null)
        {
            spawnRoutine = StartCoroutine(GetNextSpawnTimeRoutine());
        }
    }
    public IEnumerator GetNextSpawnTimeRoutine()
    {
        float waitTime = Random.Range(_minSpawnTime,_maxSpawnTime);
        yield return new WaitForSeconds(waitTime);
        SpawnEnemy();
        spawnRoutine = null;
    }
    public IEnumerator GetNextSpawnTimeRoutine(float minTime, float maxTime, Enemy_SO enemyTemplate)
    {
        float waitTime = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        SpawnEnemy(enemyTemplate);
        spawnRoutine = null;
    }
    public void SpawnEnemy()
    { 
        
        int spawnPointSlot = Random.Range(0, _spawnPoints.Count);//set position

        Enemy enemy = Instantiate(_enemyPrefab);

        if (_enemyTemplateToSpawn != null)
        {
            enemy.enemyTemplate = _enemyTemplateToSpawn;
        }
        //enemy.transform.position = _spawnPoints[spawnPointSlot].transform.position;
        enemy.transform.position = ReturnSpawnpoint().position;//will probably be done by SO
        enemy.target = _player;
        enemy.unitEventHandler.ResetHealth();
        //StartCoroutine(GetNextSpawnTimeRoutine());
    }
    public void SpawnEnemy(Enemy_SO enemyTemplate)
    {

        int spawnPointSlot = Random.Range(0, _spawnPoints.Count);//set position

        Enemy enemy = Instantiate(_enemyPrefab);

        if (_enemyTemplateToSpawn != null)
        {
            enemy.enemyTemplate = enemyTemplate;
        }
        //enemy.transform.position = _spawnPoints[spawnPointSlot].transform.position;
        enemy.transform.position = ReturnSpawnpoint().position;//will probably be done by SO
        enemy.target = _player;
        enemy.unitEventHandler.ResetHealth();
        //StartCoroutine(GetNextSpawnTimeRoutine());
    }
    public Transform ReturnSpawnpoint()
    {
        int spawnPointSlot = Random.Range(0, _spawnPoints.Count);//set position

        return _spawnPoints[spawnPointSlot].transform; ;
    }

}
