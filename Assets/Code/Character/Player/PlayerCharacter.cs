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

    private IINSTRUCTOR playerWP;
    private ICREATE playerStarterWF;

    public void Start()
    {
        SetMaxHealth(PLAYERMAXHEALTH);
        SetHealth(PLAYERMAXHEALTH);
        AddBehaviour(this.gameObject.GetComponent<PlayerMovement>());

        playerWP = GetComponent<PlayerWeaponMaster>();
        playerStarterWF = new SlashWeaponFactory();
        SetStarterWeapons(playerWP, playerStarterWF);
    }
    public int GetPlayerHealth()
    {
        return GetHealth();
    }
    public void SetPlayerHealth(int health)
    {
        SetHealth(health);
        if(HpSetEvent != null)
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

    private void SetStarterWeapons(IINSTRUCTOR playerWP, ICREATE playerStarterWF)
    {
        List<IBEHAVIOUR> starterWeapons = new WeaponConstructor().GetWeaponIBehaviours(playerWP, playerStarterWF);

        if(starterWeapons != null)
        {
            foreach(IBEHAVIOUR weapon in starterWeapons)
            {
                AddBehaviour(weapon);
            }
        }
    }
}
