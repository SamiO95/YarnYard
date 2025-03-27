using System;
using System.Collections;
using UnityEngine;
/*
*   Name could be generalized, but for clarity is ok.
*
*   WeaponAxel handles the Activation (in scene) and rotation of a WeaponBase.
*/
public class WeaponAxel : MonoBehaviour, IAXEL
{
    private float rotationSpeed = 0.6f;

    public void SetRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }
    public void Activate(float degrees)
    {
        gameObject.SetActive(true);
        StartCoroutine(Rotate(degrees));
    }
    public void Deactivate(float degrees)
    {
        gameObject.SetActive(false);
        transform.rotation = Quaternion.Euler(0, degrees, 0);
    }
    private IEnumerator Rotate(float degrees)
    {
        while(transform.rotation.y < degrees)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, degrees, transform.rotation.z), Time.deltaTime / rotationSpeed);
            yield return null;
        } 

    }
}
