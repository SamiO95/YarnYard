using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour,ITAKEDAMAGE
{
    private readonly int DEAD = 0;
    protected int health;
    public delegate void DeathEvent();    

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
        }

        health -= damage;       
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
}
