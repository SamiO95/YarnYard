using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTarget : IWEAPON
{
    [SerializeField]
    private float damageRadius;
    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject character;

    public AttackTarget(float damageRadius, int damage, GameObject target, GameObject character)
    {
        this.damage = damage;
        this.target = target;
        this.damageRadius = damageRadius;
        this.character = character;
    }

    public void Attack(int damage)
    {
        ITAKEDAMAGE damageable = target.GetComponent<ITAKEDAMAGE>();

        if (damageable != null)
        {

            //Distance to target (x_2 - x_1), y, (z_2 - z_1)
            Vector3 vectorToTarget = new Vector3(target.transform.position.x - character.transform.position.x, character.transform.position.y, target.transform.position.z - character.transform.position.z);

            //Total distance
            float distance = Mathf.Sqrt(vectorToTarget.x * vectorToTarget.x + vectorToTarget.z * vectorToTarget.z);

            //check if distance is less than damage radius
            if (distance < damageRadius)
            {
                damageable.TakeDamage(this.damage);
            }
        }
    }
}
