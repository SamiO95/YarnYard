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
    private float rotationSpeed = 1f;
    private float rotationBounds = 1f;
    private float rotationReset = 0;
    private readonly float ROTATIONMOD = 1f;

    public void SetRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }
    public void SetRotationBounds(float rotationBounds)
    {
        this.rotationBounds = rotationBounds;
    }
    public void SetRotationReset(float rotationReset)
    {
        this.rotationReset = rotationReset;
    }
    public void Activate()
    {
        gameObject.SetActive(true);
        StartCoroutine(Rotate());
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
        transform.rotation = Quaternion.Euler(0, rotationReset, 0);
    }
    private IEnumerator Rotate()
    {
        while(transform.rotation.eulerAngles.y < rotationBounds)
        {
            transform.Rotate(new Vector3(0, rotationSpeed,0) * ROTATIONMOD * Time.deltaTime);
            yield return null;
        } 

    }
}
