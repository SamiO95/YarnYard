using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 
  Enemy wave spawner handles the activation, placement and timing of Enemies.
 
  @Author: Charlie Ahlstrand
 
*/
public class EnemyWaveSpawner : MonoBehaviour
{
    private readonly int SPAWNSPACER = 10;

    public delegate void EnemyWaveDeligate();
    public event EnemyWaveDeligate WaveStartedEvent;
    public event EnemyWaveDeligate WaveFinishedEvent;

    //Temp, should be made depending on chosen difficulty.
    DifficultyMaster difficultyMaster;
    List<ICREATE> enemyFactories;

    // Initialization of EnemyWaveSpawner
    private void Start()
    {
        difficultyMaster = gameObject.GetComponent<DifficultyMaster>();

        //Temp
        enemyFactories = new List<ICREATE>() { new BearFactory() };

        SetSpawnWave();
        WaveFinishedEvent += SetSpawnWave;
    }
    private void SetSpawnWave() 
    {
        StartCoroutine(SpawnWave());
    }
    private IEnumerator SpawnWave() 
    {
        yield return new WaitForSeconds(10f);

        if (WaveStartedEvent != null)
        {
            WaveStartedEvent?.Invoke();
        }

        if (enemyFactories.Count != 0 && enemyFactories != null)
        {
            foreach (ICREATE factory in enemyFactories)
            {
                List<GameObject> enemies = factory.Create(difficultyMaster);
                OrderEnemies(enemies);
                WakeEnemies(enemies);
            }
        }

        yield return new WaitForSeconds(20f);

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
            float randomX = SPAWNSPACER * (UnityEngine.Random.value < 0.5f ? 1 : -1) + UnityEngine.Random.Range(-50f, 50f);
            float randomZ = SPAWNSPACER * (UnityEngine.Random.value < 0.5f ? 1 : -1) + UnityEngine.Random.Range(-50f, 50f);

            enemy.transform.SetPositionAndRotation(new(target.position.x + randomX, target.position.y, target.position.z + randomZ), Quaternion.identity);
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
