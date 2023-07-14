using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBear : EnemyCharacter
{
    EnemyBear(int health, int baseDamage, float reloadTimer, IWEAPON startingWeapon) : base(health, baseDamage, reloadTimer, startingWeapon)
    { }
        
}
