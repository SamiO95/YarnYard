using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour, IBEHAVIOUR
{
    private float speed;
    private GameObject obj;

    public void Behave()
    {
        //Distance to target (x_2 - x_1), y, (z_2 - z_1)
        Vector3 vectorToTarget = new (obj.transform.position.x - transform.position.x, transform.position.y, obj.transform.position.z - transform.position.z);

        //Normalization of vector v.x / abs(v)
        vectorToTarget.x = vectorToTarget.x / Mathf.Sqrt(vectorToTarget.x * vectorToTarget.x + vectorToTarget.z * vectorToTarget.z);
        vectorToTarget.z = vectorToTarget.z / Mathf.Sqrt(vectorToTarget.x * vectorToTarget.x + vectorToTarget.z * vectorToTarget.z);

        //Speed Adjustment
        vectorToTarget = new Vector3(vectorToTarget.x * speed, vectorToTarget.y, vectorToTarget.z * speed);

        transform.position = new Vector3(transform.position.x + vectorToTarget.x, transform.position.y, transform.position.z + vectorToTarget.z); 
    }

    public void SetObject(GameObject obj)
    {
        this.obj = obj; 
    }

    public void SetMovementSpeed(float speed) 
    {
        this.speed = speed;
    }

}
