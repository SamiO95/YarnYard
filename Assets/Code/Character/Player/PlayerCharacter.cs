using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{   
    [SerializeField]
    private int PLAYERMAXHEALTH = 100;
    List<IBEHAVIOUR> playerAttacks;

    public void Start() 
    {
        SetHealth(PLAYERMAXHEALTH);
        SetMaxHealth(PLAYERMAXHEALTH);
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

    public int GetPlayerMaxHealth()
    {
        return GetMaxHealth();
    }
}
