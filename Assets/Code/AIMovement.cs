using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject obj;

    AIMovement(float speed, GameObject obj) 
    {
        this.obj = obj;
        this.speed = speed;
    }

    private void Update()
    {
        //Distance to target (x_2 - x_1), y, (z_2 - z_1)
        Vector3 vectorToTarget = new Vector3(obj.transform.position.x - transform.position.x, transform.position.y, obj.transform.position.z - transform.position.z);

        //Normalization of vector v / abs(v)
        //vectorToTarget = vectorToTarget / Mathf.Abs(vectorToTarget.x + vectorToTarget.z);

        //Speed Adjustment
        vectorToTarget = new Vector3(vectorToTarget.x * speed, vectorToTarget.y, vectorToTarget.z * speed);

        transform.position = new Vector3(transform.position.x + vectorToTarget.x, transform.position.y, transform.position.z + vectorToTarget.z); 
    }

}
