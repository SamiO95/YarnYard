using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 
    The task of the Difficulty master is to relay difficulty calculations and Available enemies. 
    Spawning in enemies might be more apt to have another Class do and this one care for distribution.
 
*/
public class DifficultyMaster : MonoBehaviour, IINSTRUCTOR
{
    private int difficultyInt = 1;
    private int maxNumberOfEnemies = 100;
    private int maxAvailableGet = 20;

    [SerializeField]
    private GameObject enemyBase;
    [SerializeField]
    private Transform storageLocation;
    private DifficultyCalculator difficulty;
    private List<GameObject> enemyPool;

    //Initialization of the DifficultyMaster
    private void Start()
    {   
        //Needs to be constructed with getting its difficulty from ui settings (not created yet)
        difficulty = new DifficultyCalculator(difficultyInt);
        GenerateEnemyObjects();
    }
    //Gets the difficulty Modifier
    public float GetMod() 
    {
        return difficulty.GetTimeDifficultyMod();
    }
    //Gets the full pool of enemies
    public List<GameObject> GetObjects() 
    {
        return enemyPool;
    }
    //Gets the enemies that are not active in the scene, up to maxAvaliableGet
    public List<GameObject> GetAvailableObjects()
    {
        List<GameObject> availableEnemies = new ();
        if (enemyPool != null)
        {
            int breakCond = 0;
            foreach (GameObject enemy in enemyPool)
            {   
                if (!enemy.activeSelf)
                {
                    if (breakCond == maxAvailableGet)
                    {
                        break;
                    }

                    availableEnemies.Add(enemy);

                    breakCond++;
                    
                }
            }
        }
        return availableEnemies;
    }
    //Gets the enemies that are active in the scene
    public List<GameObject> GetUnavailableObjects()
    {
        List<GameObject> availableEnemies = new ();
        if (enemyPool != null)
        {
            foreach (GameObject enemy in enemyPool)
            {
                if (enemy.activeSelf)
                {
                    availableEnemies.Add(enemy);
                }
            }
        }
        return availableEnemies;
    }
    //Gets the object that contains the DifficultyMaster (being the target) Might be switched to a SerializeField variable
    public GameObject GetTargetObject() 
    {
        return gameObject;
    }
    //Generates a pool of enemies for the difficultymaster to handle.
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
