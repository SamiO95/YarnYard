using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : AttackingCharacter
{
    private readonly static int MAXHEALTH = 100;
    private readonly static int STARTINGBASEDAMAGE = 10;
    private readonly static float STARTINGRELOADTIME = 1f;
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

    private void CreateNewPlayer()
    {
        SetHealth(MAXHEALTH);
        baseDamage = STARTINGBASEDAMAGE;
        reloadTime = STARTINGRELOADTIME;
    }

    public List<EnemyCharacter> GetEnemyList() 
    {
        return enemies;
    }  
    public int GetPlayerHealth()
    {
        return GetHealth();
    }  

    public int GetPlayerMaxHealth()
    {
        return MAXHEALTH;
    }


    // Review Enemy Attack
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
