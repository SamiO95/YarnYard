using System.Collections.Generic;
/*
* 
*   SlashWeaponFactory Sets up any available Slash weaponry.
*
*/
public class SlashWeaponFactory : WeaponFactory
{
    private readonly float attackCooldown = 5f;
    private readonly float attackRotationLength = 180f;

    protected override void ConstructWeapon(ICORE weapon, IINSTRUCTOR weaponInstructor)
    {
        if(weapon.GetType() == ICORE.Type.Slash) 
        {
            weapon.SetBehaviour(new AttackBehaviour((int)weaponInstructor.GetMod(), new List<IWEAPON>() 
            { new AttackSlash(attackCooldown, attackRotationLength, weapon.GetObject().GetComponent<IAXEL>(), weapon.GetObject().GetComponentInChildren<IDODAMAGE>()) }));        
        }
    }

}
