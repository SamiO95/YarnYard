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

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var spawnModeProperty = serializedObject.FindProperty("spawnMode");
        var numEnemiesProperty = serializedObject.FindProperty("numEnemies");
        var spawnRadiusProperty = serializedObject.FindProperty("spawnRadius");

        EditorGUILayout.PropertyField(spawnModeProperty);

        if (spawnModeProperty.enumValueIndex == (int)SpawnMode.AroundPlayer)
        {
            EditorGUILayout.PropertyField(numEnemiesProperty);
            EditorGUILayout.PropertyField(spawnRadiusProperty);
        }
        else if (spawnModeProperty.enumValueIndex == (int)SpawnMode.Random)
        {
            EditorGUILayout.PropertyField(numEnemiesProperty);
        }

        serializedObject.ApplyModifiedProperties();
    }
}

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numEnemies = 5;

    [SerializeField]
    private float spawnRadius = 5f;

    public SpawnMode spawnMode = SpawnMode.AroundPlayer;

    private bool hasSpawnedEnemies = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSpawnedEnemies && other.CompareTag("Player"))
        {
            SpawnEnemies(other.gameObject);
            hasSpawnedEnemies = true;
        }
    }

    //private void SpawnEnemies(GameObject player)
    //{
    //    switch (spawnMode)
    //    {
    //        case SpawnMode.AroundPlayer:
    //            SpawnAroundPlayer(player);
    //            break;
    //        case SpawnMode.Random:
    //            SpawnRandom(player);
    //            break;
    //    }
    //}

    private void SpawnEnemies(GameObject player)
    {
        switch (spawnMode)
        {
            case SpawnMode.AroundPlayer:
                SpawnAroundPlayer(player);
                break;
            case SpawnMode.Random:
                StartCoroutine(SpawnRandom(player));
                break;
        }
    }

    private void SpawnAroundPlayer(GameObject player)
    {
        float angleIncrement = 360f / numEnemies;
        Vector3 playerPosition = player.transform.position;

        for (int i = 0; i < numEnemies; i++)
        {
            float angle = i * angleIncrement;
            Quaternion spawnRotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 spawnDirection = spawnRotation * Vector3.forward;
            Vector3 spawnPosition = playerPosition + spawnDirection * spawnRadius;

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            enemy.transform.up = Vector3.up;
            enemy.GetComponent<AIMovement>().SetObject(player);
        }
    }

    //private void SpawnRandom(GameObject player)
    //{
    //    Vector3 playerPosition = player.transform.position;

    //    for (int i = 0; i < numEnemies; i++)
    //    {

    //        float randomX = Random.Range(-50f, 50f);
    //        float randomZ = Random.Range(-50f, 50f);

    //        Vector3 spawnPosition = new Vector3(playerPosition.x + randomX, playerPosition.y, playerPosition.z + randomZ);
    //        Quaternion spawnRotation = Quaternion.identity;

    //        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);
    //        enemy.transform.up = Vector3.up;
    //        enemy.GetComponent<AIMovement>().SetObject(player);
    //    }
    //}

    //private IEnumerator SpawnRandom(GameObject player)
    //{
    //    Vector3 playerPosition = player.transform.position;

    //    for (int i = 0; i < numEnemies; i++)
    //    {
    //        float randomX = Random.Range(-10f, 50f);
    //        float randomZ = Random.Range(-10f, 50f);

    //        Vector3 spawnPosition = new Vector3(playerPosition.x + randomX, playerPosition.y, playerPosition.z + randomZ);
    //        Quaternion spawnRotation = Quaternion.identity;

    //        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);
    //        enemy.transform.up = Vector3.up;
    //        enemy.GetComponent<AIMovement>().SetObject(player);

    //        yield return new WaitForSeconds(1f);
    //    }

    //    yield break;
    //}

    private IEnumerator SpawnRandom(GameObject player)
    {
        Vector3 playerPosition = player.transform.position;
        int enemiesSpawned = 0;

        while (enemiesSpawned < numEnemies)
        {
            float randomX = Random.Range(-50f, 50f);
            float randomZ = Random.Range(-50f, 50f);

            Vector3 spawnPosition = new Vector3(playerPosition.x + randomX, playerPosition.y, playerPosition.z + randomZ);
            Quaternion spawnRotation = Quaternion.identity;

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            enemy.transform.up = Vector3.up;
            enemy.GetComponent<AIMovement>().SetObject(player);

            enemiesSpawned++;
            yield return new WaitForSeconds(1f);
        }
    }
}

