using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour, ITAKEDAMAGE
{
    private readonly int DEAD = 0;
    protected int health;
    public delegate void DeathEvent();    

    public Character(int health) 
    {
        this.health = health;
    }

    public void TakeDamage(int damage) 
    {
        if ((health - damage) <= DEAD) 
        {
            health = DEAD;

            Die();
        }

        health -= damage;       
    }

    protected virtual void Die(){}
}
