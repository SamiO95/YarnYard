using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 
    The task of the Difficulty master is to relay difficulty calculations and Available enemies. 
    Spawning in enemies might be more apt to have another Class do and this one care for distribution.
 
*/
public class DifficultyMaster : MonoBehaviour
{
    int difficultyInt = 1;
    int maxNumberOfEnemies = 100;

    [SerializeField]
    GameObject enemyBase;
    [SerializeField]
    Transform storageLocation;
    DifficultyCalculator difficulty;
    List<GameObject> enemyPool;

    void Start()
    {   
        //Needs to be constructed with getting its difficulty from ui settings (not created yet)
        difficulty = new DifficultyCalculator(difficultyInt);
        GenerateEnemyObjects();
    }

    public float GetDifficultyMod() 
    {
        return difficulty.GetTimeDifficultyMod();
    }

    public List<GameObject> GetEnemyPool() 
    {
        return enemyPool;
    }
    public List<GameObject> GetEnemyAvailablePool()
    {
        List<GameObject> availableEnemies = new ();

        foreach (GameObject enemy in enemyPool)
        {
            if(!enemy.activeSelf)
            {
                availableEnemies.Add(enemy);
            }
        }

        return availableEnemies;
    }
    private void GenerateEnemyObjects() 
    {
        enemyPool = new List<GameObject>();

        for (int i = 0 ; i < maxNumberOfEnemies ; i++)
        {
            GameObject newEnemy = Instantiate(enemyBase, storageLocation);
            newEnemy.name += i;
            enemyPool.Add(newEnemy);
        } 
    }

}
