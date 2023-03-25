using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter: Character
{

    private int baseDamage;
    private List<IWEAPON> weapons;

    PlayerCharacter(int health, int baseDamage, IWEAPON startingWeapon) : base(health)
    {
        this.baseDamage = baseDamage;
        weapons = new List<IWEAPON>();
        weapons.Add(startingWeapon);
    }

    public void ReadyToAttack() 
    {
        foreach (IWEAPON weapon in weapons)
        {
            weapon?.attack(baseDamage);
        }
    }
    

}
