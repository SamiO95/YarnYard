using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnEnemy(other);
        }
    }

    private void SpawnEnemy(Collider player)
    {
       GameObject enemy =  Instantiate(enemyPrefab, transform.position, transform.rotation);
       enemy.GetComponent<AIMovement>().SetObject(player.gameObject); 
    }

}

