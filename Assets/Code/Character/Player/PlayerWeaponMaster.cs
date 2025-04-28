using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponMaster : MonoBehaviour, IINSTRUCTOR
{
    [SerializeField]
    GameObject slashBase;
    [SerializeField]
    Transform storageLocation;

    private readonly float playerStrength = 1;

    private List<GameObject> weaponPool;

    public void Awake()
    {
        GenerateWeaponObjects();
    }
    public float GetMod()
    {
        return playerStrength;
    }
    public List<GameObject> GetAvailableObjects()
    {
        List<GameObject> unavailableWeapons = new();
        if(weaponPool != null)
        {
            foreach(GameObject weapon in weaponPool)
            {
                if(!weapon.activeSelf)
                {
                    unavailableWeapons.Add(weapon);
                }
            }
        }
        return unavailableWeapons;
    }
    public List<GameObject> GetUnavailableObjects()
    {
        List<GameObject> unavailableWeapons = new();
        if(weaponPool != null)
        {
            foreach(GameObject weapon in weaponPool)
            {
                if(weapon.activeSelf)
                {
                    unavailableWeapons.Add(weapon);
                }
            }
        }
        return unavailableWeapons;
    }
    public List<GameObject> GetObjects()
    {
        return weaponPool;
    }
    public GameObject GetTargetObject()
    {
        return gameObject;
    }
    private void GenerateWeaponObjects()
    {
        GameObject weaponObject = Instantiate(slashBase, storageLocation);
        weaponObject.SetActive(false);
        weaponPool = new List<GameObject>() { weaponObject };
    }
}
