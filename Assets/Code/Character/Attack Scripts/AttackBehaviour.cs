using System.Collections.Generic;

/*
*
*   AttackBehaviour interfaces between IWEAPON's and IBEHAVIOUR's.
*   To add an attack as a behaviour, add the IWEAPON to the AttackBehaviour upon contruction.
*
*/

public class AttackBehaviour : IBEHAVIOUR
{
    private readonly int damage;
    private readonly List<IWEAPON> weapons;

    public AttackBehaviour(int damage, List<IWEAPON> startingWeapons)
    {
        this.damage = damage;
        weapons = new List<IWEAPON>();
        foreach (IWEAPON weapon in startingWeapons)
        {
            weapons.Add(weapon);
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
