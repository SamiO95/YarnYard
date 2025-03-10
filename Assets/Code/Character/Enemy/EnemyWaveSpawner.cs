using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public delegate void EnemyWaveDeligate();
    public event EnemyWaveDeligate WaveStartedEvent;
    public event EnemyWaveDeligate WaveFinishedEvent;

    DifficultyCalculator difficulty;
    List<EnemyFactory> enemyFactories;

    // Initialization of EnemyWaveSpawner
    private void Start()
    {
        //WaveFinishedEvent += SpawnWave;
    }
    private void SpawnWave() 
    {
        if (WaveStartedEvent != null)
        {
            WaveStartedEvent?.Invoke();
        }

        foreach (EnemyFactory factory in enemyFactories)
        {
            factory.Create(difficulty);
        }

        if (WaveFinishedEvent != null)
        {
            WaveStartedEvent?.Invoke();
        }
    }
}
