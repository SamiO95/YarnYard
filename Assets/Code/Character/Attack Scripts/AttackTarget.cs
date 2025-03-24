using UnityEngine;

public class AttackTarget : IWEAPON
{
    private readonly float damageRadius;
    private readonly float attackCooldown;
    private readonly ITAKEDAMAGE target;
    private readonly GameObject character;
    private bool onCooldown = false;

    public AttackTarget(float damageRadius, float attackCooldown, ITAKEDAMAGE target, GameObject character)
    {
        this.target = target;
        this.attackCooldown = attackCooldown;
        this.damageRadius = damageRadius;
        this.character = character;
    }

    public void Attack(int damage)
    {
        if(!onCooldown)
        {
            GameObject damageableObject = target.GetDamagableCharacter();

            if(damageableObject != null)
            {
                //Distance to target (x_2 - x_1), y, (z_2 - z_1)
                Vector3 vectorToTarget = new(damageableObject.transform.position.x - character.transform.position.x, character.transform.position.y, damageableObject.transform.position.z - character.transform.position.z);

                //Total distance
                float distance = Mathf.Sqrt(vectorToTarget.x * vectorToTarget.x + vectorToTarget.z * vectorToTarget.z);

                //check if distance is less than damage radius
                if(distance < damageRadius)
                {
                    target.TakeDamage(damage);
                    Cooldown(attackCooldown);
                }
            }
        }
    }
    private void Cooldown(float attackCooldown)
    {
        onCooldown = true;
        TimerUtil.Instance.SetTimer(attackCooldown, ResetCooldown);
    }

    private void ResetCooldown()
    {
        onCooldown = false;
    }
}
