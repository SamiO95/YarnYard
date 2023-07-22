using System;
using System.Collections.Generic;

public class AttackingCharacter : Character
{
    protected int baseDamage;
    protected int damage;
    protected float reloadTime;
    protected List<IWEAPON> weapons;
    private readonly int EMPTY = 0;

    protected AttackingCharacter(int health, int baseDamage, float reloadTime, List<IWEAPON> startingWeapons) : base(health)
    {
        this.baseDamage = baseDamage;
        this.reloadTime = reloadTime;
        weapons = new List<IWEAPON>();
        foreach (IWEAPON w in startingWeapons)
        {
            weapons.Add(w);
        }
    }

    public void Attack() 
    {
        CycleAttacks();
        SetTimer(reloadTime, Attack);
    }

    protected void CycleAttacks() 
    {
        if (weapons != null && weapons.Count != EMPTY)
        {
            foreach (IWEAPON att in weapons)
            {
                att.Attack(damage);
            }
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
