using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    private readonly int SPAWNSPACER = 10;

    public delegate void EnemyWaveDeligate();
    public event EnemyWaveDeligate WaveStartedEvent;
    public event EnemyWaveDeligate WaveFinishedEvent;

    //Temp, should be made depending on chosen difficulty.
    DifficultyMaster difficultyMaster;
    List<EnemyFactory> enemyFactories;

    // Initialization of EnemyWaveSpawner
    private void Start()
    {
        difficultyMaster = gameObject.GetComponent<DifficultyMaster>();
        //Temp
        enemyFactories = new List<EnemyFactory>() { new BearFactory() };
    
        //WaveFinishedEvent += SetSpawnWave;
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

        if (enemyFactories.Count != 0 && enemyFactories != null)
        {
            foreach (EnemyFactory factory in enemyFactories)
            {
                List<GameObject> enemies = factory.Create(difficultyMaster);
                OrderEnemies(enemies);
                WakeEnemies(enemies);
            }
        }

        yield return new WaitForSeconds(difficultyMaster.GetMod());

        if (WaveFinishedEvent != null)
        {
            WaveStartedEvent?.Invoke();
        }
    }
    private void OrderEnemies(List<GameObject> unorderedEnemies) 
    {
        Transform target = difficultyMaster.GetTargetObject().transform;

        foreach (GameObject enemy in unorderedEnemies)
        {
            float randomX = SPAWNSPACER + UnityEngine.Random.Range(-50f, 50f);
            float randomZ = SPAWNSPACER + UnityEngine.Random.Range(-50f, 50f);

            Vector3 spawnPosition = new (target.position.x + randomX, target.position.y, target.position.z + randomZ);

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

    /*
    // Made By Sami Ouzaa
    private void SpawnAroundPlayer()
    {
        float angleIncrement = 360f / numEnemies;
        Vector3 esp = transform.position;

        for (int i = 0 ; i < numEnemies ; i++)
        {
            float angle = i * angleIncrement;
            Quaternion spawnRotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 spawnDirection = spawnRotation * Vector3.forward;
            Vector3 spawnPosition = esp + spawnDirection * spawnRadius;

            List<GameObject> enemies = bearCreater.Create();

            foreach (GameObject enemy in enemies)
            {
                enemy.transform.SetPositionAndRotation(spawnPosition, spawnRotation);
            }

        }
    }*/

}
