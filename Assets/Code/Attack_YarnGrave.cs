using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_YarnGrave : IWEAPON
{

    [SerializeField]
    private AttackSpawner attackSpawner;
    [SerializeField]
    private GameObject attackObject;
    [SerializeField]
    private Transform attackDirection;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float time;
    [SerializeField]
    private string target;

    Attack_YarnGrave(AttackSpawner attackSpawner, GameObject attackObject, Transform attackDirection, float speed, float time, string target) 
    {
        this.attackSpawner = attackSpawner;
        this.attackObject = attackObject;
        this.attackDirection = attackDirection;
        this.speed = speed;
        this.time = time;
        this.target = target;
    }


    public void Attack(int damage) 
    {
        if (attackSpawner != null)
        {
            attackSpawner.InstantiateAttack(attackObject, attackDirection, target, speed, time, damage);
        }
    }


}
