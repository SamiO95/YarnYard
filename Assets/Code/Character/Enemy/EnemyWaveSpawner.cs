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
    DifficultyCalculator difficulty = new ();
    List<EnemyFactory> enemyFactories;

    // Initialization of EnemyWaveSpawner
    private void Start()
    {
        
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
            List<GameObject> enemies = factory.Create(difficulty);
            OrderEnemies(enemies);
            WakeEnemies(enemies);
        }

        yield return new WaitForSeconds(difficulty.GetTimeDifficultyMod());

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
            enemy.SetActive(true);
        }
    }
}
