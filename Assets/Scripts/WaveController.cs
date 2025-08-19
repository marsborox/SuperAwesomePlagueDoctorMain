using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;


    int _spawnedEnemiesThisWave = 0;
    private int _waveIndex = 0;
    [SerializeField] private List<Wave_SO> _waves = new List<Wave_SO>();
    void Start()
    {
        
    }

    void Update()
    {
        WaveControllFlow();
    }
    private void WaveControllFlow()
    {
        ProcessWave(_waves[_waveIndex]);
    }
    private void ProcessWave(Wave_SO waveSO)
    {
        var enemySpawner = gameManager.enemySpawner;
        if (enemySpawner.spawnRoutine == null)
        {
            enemySpawner.spawnRoutine = enemySpawner.StartCoroutine(enemySpawner.GetNextSpawnTimeRoutine(waveSO.minSpawnTime,waveSO.maxSpawnTime,waveSO.enemySO));
            _spawnedEnemiesThisWave++;
            //Debug.Log("enemy will spawn (wave controller)");
        }
        if (_spawnedEnemiesThisWave==waveSO.numberOfEnemies)
        {
            PostWave();
        }
    }
    private void PostWave()
    {
        Debug.Log("WaveEnded");
        _spawnedEnemiesThisWave = 0;
        _waveIndex++;
        if (_waveIndex == _waves.Count)
        { 
            _waveIndex = 0;
        }
    }
}
