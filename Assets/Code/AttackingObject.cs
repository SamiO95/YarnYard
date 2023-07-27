using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingObject : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private Vector3 dir;
    [SerializeField]
    private string targetTag;
    [SerializeField]
    private int damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
            ITAKEDAMAGE target = other.GetComponent<ITAKEDAMAGE>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }


}
