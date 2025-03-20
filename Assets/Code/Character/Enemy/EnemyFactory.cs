using System.Collections.Generic;
using UnityEngine;

/*
    Base class for EnemyFactories, Children of this class alters ConstructEnemy and keeps set Values.
*/

public class EnemyFactory : ICREATE
{
    //Takes an instructor that handles objects with EnemyObject
    public List<GameObject> Create(IINSTRUCTOR difficultyMaster)
    {
        List<GameObject> enemies = difficultyMaster.GetAvailableObjects();
        
        foreach (GameObject enemyObject in enemies)
        {
            EnemyCharacter enemy = enemyObject.GetComponent<EnemyCharacter>();

            if (enemy != null) 
            {
                ConstructEnemy(enemy, difficultyMaster);
            }
        }
        return enemies;
    }
    protected virtual EnemyCharacter ConstructEnemy(EnemyCharacter enemy, IINSTRUCTOR instructor) { return enemy; }
}
