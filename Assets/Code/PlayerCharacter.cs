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

    PlayerCharacter(int health, int baseDamage, float reloadTime, List<IWEAPON> startingWeapon) : base(health, baseDamage, reloadTime, startingWeapon)
    {}

    private void Start()
    {
        CreateNewPlayer();
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

}
