using System.Collections.Generic;
using UnityEngine;
/*
*
*   WeaponConstructor assembles and returns available weapon IBEHAVIOUR's depending on the entered weaponInstructor and weaponFactory.
*   Requires the weapon's GameObject to contain an ICORE.
*
*/

public class WeaponConstructor
{
    public List<IBEHAVIOUR> GetWeaponIBehaviours(IINSTRUCTOR weaponInstructor, ICREATE weaponFactory) 
    {
        List<IBEHAVIOUR> weapons = new ();
        List<GameObject> weaponObjects = weaponFactory.Create(weaponInstructor);

        if(weaponObjects != null)
        {
            foreach(GameObject weaponObject in weaponObjects)
            {
                ICORE weaponCore = weaponObject.GetComponent<ICORE>();

                if(weaponCore != null) 
                {
                    weapons.Add(weaponObject.GetComponent<ICORE>().GetBehaviour());
                }
            }
        }
        return weapons;
    }


}
