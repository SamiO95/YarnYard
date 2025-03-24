using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*
*   WeaponCore handles the instance of the attackBehaviour and its type.
*
*/
public class WeaponCore : MonoBehaviour, ICORE
{
    [SerializeField]
    private ICORE.Type weaponType;

    private IBEHAVIOUR weaponBehaviour;
    ICORE.Type ICORE.GetType()
    {
        return weaponType;
    }

    public IBEHAVIOUR GetBehaviour()
    {
        return weaponBehaviour;
    }
    public void SetBehaviour(IBEHAVIOUR weaponBehaviour)
    {
        this.weaponBehaviour = weaponBehaviour;
    }
    public GameObject GetObject()
    {
        return gameObject;
    }
}
