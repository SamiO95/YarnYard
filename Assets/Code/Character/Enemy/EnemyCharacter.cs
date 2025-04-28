using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public void WakeEnemy() 
    {
        this.gameObject.SetActive(true);
    }
    public int GetEnemyHealth() 
    {
        return GetHealth();
    }
    public void SetEnemyHealth(int health) 
    {
        SetHealth(health);
    }
    public void SetEnemyMaxHealth(int maxHealth)
    {
        SetMaxHealth(maxHealth);
    }
    public void AddEnemyBehaviour(IBEHAVIOUR act)
    {
        AddBehaviour(act);
    }
    public void SetEnemyBehaviour(IBEHAVIOUR act)
    {
        SetBehaviour(act);
    }
}
