using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackingObject : MonoBehaviour
{
    [SerializeField]
    private string targetTag;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int damage;

    public void SetInstance(string targetTag, float speed, float time, int damage)
    {
        this.targetTag = targetTag;
        this.speed = speed;
        this.damage = damage;
        SetTimer(time, DestroyThisObject);
    }

    private void SetTimer(float _Time, Action _TimerAction)
    {
        StartCoroutine(Timer(_Time, _TimerAction));
    }

    private void DestroyThisObject() 
    {
        Destroy(this.gameObject);
    }

    private IEnumerator Timer(float _Time, Action _TimerAction)
    {
        yield return new WaitForSeconds(_Time);

        _TimerAction();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
    }


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
