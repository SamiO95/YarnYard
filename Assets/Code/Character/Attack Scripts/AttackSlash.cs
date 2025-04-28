using System;
/*
*
*   AttackSlash is an IWEAPON that calls for an IAXEL to start rotating and SetActive on a Damaging Collider.
*   Locks the Attack from being called multiple times, until a set amount of time has passed, finishing the cooldown.
* 
*/
public class AttackSlash : IWEAPON
{
    public event IWEAPON.AttackDeligate AttackEvent;
    public event IWEAPON.AttackDeligate AttackCooldownEvent;
    public event IWEAPON.DamageDeligate DamageEvent;
    private readonly float attackCooldown;
    private readonly float attackStopMod;
    private bool onCooldown = false;

    public AttackSlash(float attackCooldown, float attackStopMod)
    {
        this.attackCooldown = attackCooldown;
        this.attackStopMod = attackStopMod;
    }
    public void Attack(int damage)
    {
        if (!onCooldown)
        {
            AttackEvent?.Invoke();
            DamageEvent?.Invoke(damage);
            Cooldown();
        }
    }

    private void Cooldown()
    {
        onCooldown = true;
        TimerUtil.Instance.SetTimer(attackCooldown/attackStopMod, DeactivateAttack);
        TimerUtil.Instance.SetTimer(attackCooldown, ResetCooldown);
    }

    private void ResetCooldown()
    {
        onCooldown = false;
    }

    private void DeactivateAttack()
    {
        AttackCooldownEvent?.Invoke();
    }
}
