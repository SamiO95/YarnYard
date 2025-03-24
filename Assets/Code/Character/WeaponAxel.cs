using System;
using System.Collections;
using UnityEngine;
/*
*   Name could be generalized, but for clarity is ok.
*
*   WeaponAxel handles the Activation (in scene) and rotation of a WeaponBase.
*
*
*/
public class WeaponAxel : MonoBehaviour, IAXEL
{
    private float rotationSpeed = 1;
    private float rotationAmount = 1;

    public void SetRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }
    public void SetRotationAmount(float rotationAmount)
    {
        gameObject.SetActive(true);
        this.rotationAmount = rotationAmount;
    }
    public void Activate(float degrees)
    {
        StartCoroutine(Rotate(degrees));
    }
    public void Deactivate(float degrees)
    {
        gameObject.SetActive(false);
        transform.Rotate(0,degrees, 0);
    }
    private IEnumerator Rotate(float degrees) 
    {
        while(transform.rotation.y < degrees) 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + rotationAmount, transform.rotation.z), rotationSpeed);
            yield return null;
        }
    }
}
