using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IBEHAVIOUR
{
    private enum direction { Right, Left, Up, Down };
    private direction currentDirection = direction.Right;
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private Transform playerSpriteObject;
    

    public void Behave()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);

                if (currentDirection == direction.Right) 
                {
                    playerSpriteObject.localScale = new (-1, 1, 1);
                    currentDirection = direction.Left;
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);

                if (currentDirection == direction.Left)
                {
                    playerSpriteObject.localScale = new(1, 1, 1);
                    currentDirection = direction.Right;
                }
            }
        }
    }
}
