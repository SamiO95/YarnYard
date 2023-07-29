using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    
    public void InstantiateAttack(GameObject attackingObject, Transform direction, string target, float speed, float time, int damage)
    {
        GameObject attObj = Instantiate(attackingObject, direction);
        attObj.GetComponent<AttackingObject>().SetInstance(target, speed, time, damage);
    }

}
