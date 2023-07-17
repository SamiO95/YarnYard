using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBear : EnemyCharacter
{
    public EnemyBear(int health, int baseDamage, float reloadTime, List<IWEAPON> startingWeapons) : base(health, baseDamage, reloadTime, startingWeapons)
    { }

    public void SetInstance(int health, int baseDamage, float reloadTime, List<IWEAPON> startingWeapons) 
    {
        this.health = health;
        this.baseDamage = baseDamage;
        this.reloadTime = reloadTime;

        if (weapons != null)
        {
            weapons.Clear();
            foreach (IWEAPON w in startingWeapons)
            {
                weapons.Add(w);
            }
        }
        else
        {
            weapons = new List<IWEAPON>();        
    
            foreach (IWEAPON w in startingWeapons)
            {
                weapons.Add(w);
            }
        }
        
        
    }

}
