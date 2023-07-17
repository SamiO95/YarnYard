using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : AttackingCharacter
{
   
    protected EnemyCharacter(int health, int baseDamage, float reloadTimer, List<IWEAPON> startingWeapons) : base(health, baseDamage, reloadTimer, startingWeapons)
    { }    

    

    protected override void Die()
    {
        if (gameObject != null)
        {
            //Drop Player exp?
            Destroy(gameObject);
        }
    }

}
