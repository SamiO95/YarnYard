using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : AttackingCharacter
{

    public event DeathEvent EnemyDeathEvent;
    public event DamageTakenEvent EnemyDamagedEvent;

    protected EnemyCharacter(int health, int baseDamage, float reloadTimer, List<IWEAPON> startingWeapons) : base(health, baseDamage, reloadTimer, startingWeapons) { }    

    

    protected override void Die()
    {
        if (gameObject != null)
        {
            EnemyDeathEvent?.Invoke();
        }
    }

    protected override void DamageTaken()
    {
        if (gameObject != null)
        {
            EnemyDamagedEvent?.Invoke();
        }
    }
}
