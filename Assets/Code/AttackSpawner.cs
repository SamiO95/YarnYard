using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour
{
    
    public void InstantiateAttack(GameObject attackingObject, Transform location, int damage) 
    {
        GameObject attObj = Instantiate(attackingObject, location);


    }

}
