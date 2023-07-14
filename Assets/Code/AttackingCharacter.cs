using System;
using System.Collections.Generic;

public class AttackingCharacter : Character
{
    protected int baseDamage;
    protected int damage;
    protected float reloadTime;
    protected List<IWEAPON> weapons;

    protected AttackingCharacter(int health, int baseDamage, float reloadTime, IWEAPON startingWeapon) : base(health)
    {
        this.baseDamage = baseDamage;
        this.reloadTime = reloadTime;
        weapons = new List<IWEAPON>();
        weapons.Add(startingWeapon);
    }

    protected void CycleAttacks() 
    {
        foreach (IWEAPON att in weapons) 
        {
            att.Attack(damage);
        }
    }

    public void EditDamage(int damageChange) 
    {
        damage += damageChange;
    }
    public void ResetDamage()
    {
        damage = baseDamage;
    }

    public void editBaseDamage(int damageChange)
    {
        baseDamage += damageChange;
    }

}
