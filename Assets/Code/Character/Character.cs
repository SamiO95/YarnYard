using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 
    Character Class
    The character class signifies an object,
    that is able to take damage and die through the interface ITAKEDAMAGE.

*/
public class Character: MonoBehaviour, ITAKEDAMAGE
{
    private int DEAD = 0;
    protected int health;
    public delegate void DeathEvent();
    public delegate void DamageTakenEvent();

    protected Character(int health) 
    {
        this.health = health;
    }

    public void TakeDamage(int damage) 
    {
        if ((health - damage) <= DEAD) 
        {
            health = DEAD;

            Die();
            return;
        }

        health -= damage;
        DamageTaken();
    }

    protected void SetTimer(float _Time, Action _TimerAction)
    {
        StartCoroutine(Timer(_Time, _TimerAction));
    }

    private IEnumerator Timer(float _Time, Action _TimerAction)
    {
        yield return new WaitForSeconds(_Time);

        _TimerAction();
    }

    protected virtual void Die(){}
    protected virtual void DamageTaken() { }
}
