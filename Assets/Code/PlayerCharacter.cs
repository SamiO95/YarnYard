using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter: AttackingCharacter
{ 
    public event EventHandler PlayerDeathEvent;

    private readonly int startingHealth = 100;
    private readonly int startingBaseDamage = 10;
    private readonly float startingReloadTime = 1f;
    private IWEAPON startingWeapon;
    private List<EnemyCharacter> enemies;

    PlayerCharacter(int health, int baseDamage, float reloadTime, List<IWEAPON> startingWeapon) : base(health, baseDamage, reloadTime, startingWeapon)
    {}

    private void Start()
    {
        CreateNewPlayer();
        enemies = new List<EnemyCharacter>();
        Attack();
    }

    protected override void Die() 
    {
        if (gameObject != null) 
        {
            Debug.Log("Player dead");
            PlayerDeathEvent?.Invoke(this, System.EventArgs.Empty);
        }
    }

    private void CreateNewPlayer()
    {
        health = startingHealth;
        baseDamage = startingBaseDamage;
        reloadTime = startingReloadTime;
    }

    public List<EnemyCharacter> GetEnemyList() 
    {
        return enemies;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            if (other.GetComponent<EnemyCharacter>() != null)
            {
                enemies.Add(other.GetComponent<EnemyCharacter>());
                //Mark target fx?
            }
        }
    }


}
