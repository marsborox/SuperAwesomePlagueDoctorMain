using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;

    Wave_SO wave1;
    Wave_SO wave2;
    Wave_SO wave3;
    private int _spawnedEnemiesThisWave = 0;
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
        if (gameManager.enemySpawner.spawnRoutine != null)
        {
            gameManager.enemySpawner.GetNextSpawnTimeRoutine(waveSO.minSpawnTime,waveSO.maxSpawnTime,waveSO.enemySO);
        }
        _spawnedEnemiesThisWave++;
        if (_spawnedEnemiesThisWave==waveSO.numberOfEnemies)
        {
            PostWave();
        }
    }
    private void PostWave()
    {
        _spawnedEnemiesThisWave = 0;
        _waveIndex++;
        if (_waveIndex == _waves.Count)
        { 
            _waveIndex = 0;
        }
    }
}
