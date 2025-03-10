using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Character Class
    The character class signifies an object,
    able to take damage and die through the interface ITAKEDAMAGE,
    and behave a certain way through the IBEHAVIOUR interface.
    Timer Utility should later be moved to be its own class.
*/
public class Character : MonoBehaviour, ITAKEDAMAGE
{
    //Events for handling Character response upon ITAKEDAMAGE
    public delegate void DamageTakenDeligate();
    public delegate void DeathDeligate();
    public event DeathDeligate DeathEvent;
    public event DamageTakenDeligate DamagedEvent;

    private List<IBEHAVIOUR> actions;

    private int MAXHEALTH;
    private int health;
    private readonly int DEAD = 0;

    //Enables an action to be run during runtime
    public void FixedUpdate()
    {
        if (actions != null)
        {
            foreach (IBEHAVIOUR act in actions)
            {
                act.Behave();
            }
        }
    }
    //Makes the character take damage, invoking the DamagedEvent, and die, invoking the DieEvent. 
    public void TakeDamage(int damage) 
    {
        if ((health - damage) <= DEAD) 
        {
            health = DEAD;
            if (DeathEvent != null)
            {
                DeathEvent?.Invoke();
            }
                
            return;
        }

        health -= damage;
        if (DamagedEvent != null)
        {
            DamagedEvent?.Invoke();
        }
    }
    //Add/change behaviour
    protected void AddBehaviour(IBEHAVIOUR act) 
    {
        if (actions != null)
        {
            actions.Add(act);
        }
        else
        {
            actions = new List<IBEHAVIOUR>(){act};
        }
    }
    protected void SetBehaviour(IBEHAVIOUR act) 
    {
        actions = new List<IBEHAVIOUR>() { act };
    }
    //Enables Children to set/get health
    protected void SetHealth(int health) 
    {
        if (health < MAXHEALTH)
        {
            this.health = health;
        }
        else
        {
            this.health = MAXHEALTH;
        }
    }
    protected int GetHealth() 
    {
        return health;    
    }
    //Enables Children to get/set maxhealth
    protected int GetMaxHealth()
    {
        return MAXHEALTH;
    }
    protected void SetMaxHealth(int maxHealth)
    {
        this.MAXHEALTH = maxHealth;
    }
    
    //Timer utility, May be moved for more apt application
    protected void SetTimer(float _Time, Action _TimerAction)
    {
        StartCoroutine(Timer(_Time, _TimerAction));
    }

    private IEnumerator Timer(float _Time, Action _TimerAction)
    {
        yield return new WaitForSeconds(_Time);

        _TimerAction();
    }
}
