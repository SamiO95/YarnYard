using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    public int GetEnemyHealth() 
    {
        return GetHealth();
    }

    public void SetEnemyHealth(int health) 
    {
        SetHealth(health);
    }

    public void AddEnemyBehaviour(IBEHAVIOUR act)
    {
        AddBehaviour(act);
    }
    public void SetEnemyBehaviour(IBEHAVIOUR act)
    {
        SetBehaviour(act);
    }

    public void SetEnemyMaxHealth(int maxHealth)
    {
        SetMaxHealth(maxHealth);
    }
}
