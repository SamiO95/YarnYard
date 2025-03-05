using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : IBEHAVIOUR
{
    protected int damage;
    protected List<IWEAPON> weapons;

    protected AttackBehaviour(int damage, List<IWEAPON> startingWeapons)
    {
        this.damage = damage;
        weapons = new List<IWEAPON>();
        foreach (IWEAPON w in startingWeapons)
        {
            weapons.Add(w);
        }
    }

    public void Behave() 
    { 
        
    }

    

}
