using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    AttackSlash is an IWEAPON that calls for an IAXEL to start rotating and SetActive on a Damaging Collider.
    Locks the Attack from being called multiple times, until a set amount of time has passed, finishing the cooldown.
 
 
*/
public class AttackSlash : IWEAPON
{
    private readonly float attackCooldown;
    private readonly IAXEL slashAxel;
    private bool onCooldown = false;

    public AttackSlash(float attackCooldown, IAXEL slashAxel)
    {
        this.attackCooldown = attackCooldown;
        this.slashAxel = slashAxel;
    }

    public void Attack(int damage)
    {
        if(!onCooldown)
        {
            slashAxel.Activate(damage);
            onCooldown = true;
            Cooldown(attackCooldown, slashAxel);
        }
    }
    private void Cooldown(float attackCooldown, IAXEL axel)
    {
        axel.SetTimer(attackCooldown, ResetCooldown);
    }

    private void ResetCooldown()
    {
        onCooldown = false;
    }
}
