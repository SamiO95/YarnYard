using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public delegate void HealthSetDeligate();
    public event HealthSetDeligate MaxHpSetEvent;
    public event HealthSetDeligate HpSetEvent;

    [SerializeField]
    private int PLAYERMAXHEALTH;
    private List<IBEHAVIOUR> playerAttacks;

    public void Start() 
    {
        SetMaxHealth(PLAYERMAXHEALTH);
        SetHealth(PLAYERMAXHEALTH);
        AddBehaviour(this.gameObject.GetComponent<PlayerMovement>());
    
        /*foreach (IBEHAVIOUR act in playerAttacks)
        {
            AddBehaviour(act);
        }*/
    }
    public int GetPlayerHealth()
    {
        return GetHealth();
    }
    public void SetPlayerHealth(int health) 
    {
        SetHealth(health);
        if (HpSetEvent != null)
            HpSetEvent?.Invoke();
    }
    public int GetPlayerMaxHealth()
    {
        return GetMaxHealth();
    }
    public void SetPlayerMaxHealth(int maxHealth)
    {
        SetMaxHealth(maxHealth);

        if(MaxHpSetEvent != null)
            MaxHpSetEvent?.Invoke();
    }
}
