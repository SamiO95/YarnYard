using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : AttackingCharacter
{
   
    protected EnemyCharacter(int health, int baseDamage, float reloadTimer, IWEAPON startingWeapon) : base(health, baseDamage, reloadTimer, startingWeapon)
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
