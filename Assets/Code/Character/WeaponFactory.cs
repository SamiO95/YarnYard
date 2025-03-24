using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponFactory : ICREATE
{
    public List<GameObject> Create(IINSTRUCTOR weaponInstructor)
    {
        List<GameObject> weapons = weaponInstructor.GetAvailableObjects();

        foreach(GameObject weaponObject in weapons)
        {
            ICORE weapon = weaponObject.GetComponent<ICORE>();

            if(weapon != null)
            {
                ConstructWeapon(weapon, weaponInstructor);
            }
        }
        return weapons;
    }

    protected abstract void ConstructWeapon(ICORE weapon, IINSTRUCTOR weaponInstructor);
}
