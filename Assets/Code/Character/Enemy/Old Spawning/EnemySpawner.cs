using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder;

public enum SpawnMode
{
    AroundPlayer,
    Random
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bearPrefab;

    CreateBear bearCreater;
    DifficultyCalculator difficulty;

    private void Start()
    {
        bearCreater = gameObject.AddComponent<CreateBear>();
        bearCreater.SetBearPrefab(bearPrefab);
        difficulty = new DifficultyCalculator();
    }

    [SerializeField]
    private int numEnemies = 5;

    [SerializeField]
    private float spawnRadius = 5f;

    public SpawnMode spawnMode = SpawnMode.AroundPlayer;

    private bool hasSpawnedEnemies = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSpawnedEnemies && other.CompareTag("EnemySpawnTrigger"))
        {
            SpawnEnemies();
            hasSpawnedEnemies = true;
        }
    }

    private void SpawnEnemies()
    {
        switch (spawnMode)
        {
            case SpawnMode.AroundPlayer:
                SpawnAroundPlayer();
                break;
            case SpawnMode.Random:
                StartCoroutine(SpawnRandom());
                break;
        }
    }

    private void SpawnAroundPlayer()
    {
        float angleIncrement = 360f / numEnemies;
        Vector3 esp = transform.position;

        for (int i = 0; i < numEnemies; i++)
        {
            float angle = i * angleIncrement;
            Quaternion spawnRotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 spawnDirection = spawnRotation * Vector3.forward;
            Vector3 spawnPosition = esp + spawnDirection * spawnRadius;

            GameObject enemy = bearCreater.Create(difficulty);
            enemy.transform.position = spawnPosition;
            enemy.transform.rotation = spawnRotation;
        }
    }

    private IEnumerator SpawnRandom()
    {
        Vector3 playerPosition = transform.position;
        int enemiesSpawned = 0;

        while (enemiesSpawned < numEnemies)
        {
            float randomX = Random.Range(-50f, 50f); 
            float randomZ = Random.Range(-50f, 50f);

            Vector3 spawnPosition = new (playerPosition.x + randomX, playerPosition.y, playerPosition.z + randomZ);
            Quaternion spawnRotation = Quaternion.identity;

            GameObject enemy = bearCreater.Create(difficulty);
            enemy.transform.SetPositionAndRotation(spawnPosition, spawnRotation);

            enemiesSpawned++;
            yield return new WaitForSeconds(1f);
        }
    }
}

