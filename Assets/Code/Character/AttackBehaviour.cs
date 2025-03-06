using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : IBEHAVIOUR
{
    private int damage;
    private List<IWEAPON> weapons;

    public AttackBehaviour(int damage, List<IWEAPON> startingWeapons)
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
        foreach (IWEAPON attack in weapons)
        {
            attack.Attack(damage);
        }
    }
}
