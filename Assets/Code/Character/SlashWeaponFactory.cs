using System.Collections.Generic;
using UnityEngine;
/*
* 
*   SlashWeaponFactory Sets up any available Slash weaponry.
*
*/
public class SlashWeaponFactory : WeaponFactory
{
    private readonly float attackCooldown = 3f;
    private readonly float attackStopMod = 1.2f;
    private readonly float attackRotationSpeed = 60f;
    private readonly float attackRotationBounds = 180f;
    private readonly float rotationReset = 0f;

    protected override void ConstructWeapon(ICORE weapon, IINSTRUCTOR weaponInstructor)
    {
        if(weapon.GetType() == ICORE.Type.Slash) 
        {
            
            GameObject weaponObject = weapon.GetObject();
            IAXEL weaponAxel = weaponObject.GetComponent<IAXEL>();
            IDODAMAGE weaponCollider = weaponObject.GetComponentInChildren<IDODAMAGE>();
            IWEAPON slashWeapon = new AttackSlash(attackCooldown, attackStopMod);

            weaponAxel.SetRotationSpeed(attackRotationSpeed);
            weaponAxel.SetRotationBounds(attackRotationBounds);
            weaponAxel.SetRotationReset(rotationReset);

            slashWeapon.DamageEvent += weaponCollider.SetDamage;
            slashWeapon.AttackEvent += weaponAxel.Activate; 
            slashWeapon.AttackCooldownEvent += weaponAxel.Deactivate;

            weapon.SetBehaviour(new AttackBehaviour((int)weaponInstructor.GetMod(), new List<IWEAPON>() 
            { slashWeapon }));        
        }
    }

}
