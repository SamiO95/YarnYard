using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : ICREATE
{
    public List<GameObject> Create(IINSTRUCTOR weaponInstructor)
    {
        throw new System.NotImplementedException();
    }

    protected virtual IWEAPON CreateWeapon(IWEAPON weapon, IINSTRUCTOR weaponInstructor) { return weapon; }

    protected virtual IBEHAVIOUR CreateAttackBehaviour(IBEHAVIOUR attackBehaviour, IINSTRUCTOR weaponInstructor) { return attackBehaviour; }

}
