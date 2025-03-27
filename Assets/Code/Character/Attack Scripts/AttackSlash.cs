using UnityEngine;
/*
*
*   AttackSlash is an IWEAPON that calls for an IAXEL to start rotating and SetActive on a Damaging Collider.
*   Locks the Attack from being called multiple times, until a set amount of time has passed, finishing the cooldown.
* 
*/
public class AttackSlash : IWEAPON
{
    private readonly float attackCooldown;
    private readonly float attackRotationLength; //Degrees
    private readonly float RESET = 0;
    private readonly IAXEL slashAxel;
    private readonly IDODAMAGE damageCollider;
    private bool onCooldown = false;

    public AttackSlash(float attackCooldown, float attackRotationLength, IAXEL slashAxel, IDODAMAGE damageCollider)
    {
        this.attackCooldown = attackCooldown;
        this.attackRotationLength = attackRotationLength;
        this.slashAxel = slashAxel;
        this.damageCollider = damageCollider;
    }

    public void Attack(int damage)
    {
        if(!onCooldown)
        {
            //No decoupling!! FIX XXXXXX
            damageCollider.SetDamage(damage);
            slashAxel.Activate(attackRotationLength);
            Cooldown(attackCooldown);
        }
    }

    private void Cooldown(float attackCooldown)
    {
        onCooldown = true;
        TimerUtil.Instance.SetTimer(attackCooldown / 2, ResetAxel);
        TimerUtil.Instance.SetTimer(attackCooldown, ResetCooldown);
    }

    private void ResetCooldown()
    {
        onCooldown = false;
    }

    private void ResetAxel() 
    {
        slashAxel.Deactivate(RESET);
    }
}
