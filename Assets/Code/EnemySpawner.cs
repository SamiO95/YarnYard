using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numEnemies = 5;
    public float spawnRadius = 5f;
    private bool hasSpawnedEnemies = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSpawnedEnemies && other.CompareTag("Player"))
        {
            SpawnEnemies(other.gameObject);
            hasSpawnedEnemies = true;
        }
    }

    private void SpawnEnemies(GameObject player)
    {
        float angleIncrement = 360f / numEnemies;
        Vector3 playerPosition = player.transform.position;

        for (int i = 0; i < numEnemies; i++)
        {
            float angle = i * angleIncrement;
            Quaternion spawnRotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 spawnDirection = spawnRotation * Vector3.forward;
            Vector3 spawnPosition = playerPosition + spawnDirection * spawnRadius;

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.transform.up = Vector3.up;
            enemy.transform.rotation *= spawnRotation;
            enemy.GetComponent<AIMovement>().SetObject(player);
        }
    }
}