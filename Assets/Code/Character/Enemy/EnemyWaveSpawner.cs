using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public delegate void EnemyWaveDeligate();
    public event EnemyWaveDeligate WaveStartedEvent;
    public event EnemyWaveDeligate WaveFinishedEvent;

    //Temp, should be made depending on chosen difficulty.
    DifficultyMaster difficulty;
    List<EnemyFactory> enemyFactories;

    // Initialization of EnemyWaveSpawner
    private void Start()
    {
        difficulty = gameObject.GetComponent<DifficultyMaster>();
        enemyFactories = new List<EnemyFactory>() { gameObject.GetComponent<EnemyFactory>() };
        //WaveFinishedEvent += SpawnWave;
    }

    private void SetSpawnWave() 
    {
        StartCoroutine(SpawnWave());
    }
        
    private IEnumerator SpawnWave() 
    {
        if (WaveStartedEvent != null)
        {
            WaveStartedEvent?.Invoke();
        }

        foreach (EnemyFactory factory in enemyFactories)
        {
            List<GameObject> enemies = factory.Create();
            OrderEnemies(enemies);
            WakeEnemies(enemies);
        }
        //Temp
        yield return new WaitForSeconds(difficulty.GetDifficultyMod());

        if (WaveFinishedEvent != null)
        {
            WaveStartedEvent?.Invoke();
        }
    }

    private void OrderEnemies(List<GameObject> unorderedEnemies) 
    {
        foreach (GameObject enemy in unorderedEnemies)
        {
            Vector3 spawnPosition = this.transform.position;
            
            enemy.transform.position = spawnPosition;
        }
    }

    private void WakeEnemies(List<GameObject> enemies) 
    {
        foreach (GameObject enemy in enemies) 
        {
            enemy.GetComponent<EnemyCharacter>().WakeEnemy();
        }
    }
}
