using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_YarnGrave : IWEAPON
{

    [SerializeField]
    private AttackSpawner attackSpawner;
    [SerializeField]
    private GameObject attObj;
    [SerializeField]
    private Transform attackDir;


    Attack_YarnGrave(AttackSpawner attackSpawner, GameObject attObj, Transform attackDir) 
    {
        this.attackSpawner = attackSpawner;
        this.attObj = attObj;
        this.attackDir = attackDir;
    }


    public void Attack(int damage) 
    {
        attackSpawner.InstantiateAttack(attObj, attackDir, damage); 
    }


}
