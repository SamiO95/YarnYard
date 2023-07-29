using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBear : MonoBehaviour, ICREATE
{
    CreateBear() { }

    [SerializeField]
    GameObject bearPrefab;

    private static readonly int BASEHEALTH = 10; 
    private static readonly float HEALTHMOD = 1.1f;
    private static readonly int BASEDAMAGE = 10;
    private static readonly float DAMAGEMOD = 1.1f;
    private static readonly float RELOADTIME = 1f;
    private static readonly float MELEERANGE = 2f;

    public GameObject Create(float time, GameObject player)
    {
        GameObject bear = Instantiate(bearPrefab);

        float bearHealth = BASEHEALTH + time * HEALTHMOD;

        List<IWEAPON> bearWeapon = new List<IWEAPON>();
        bearWeapon.Add(CreateNewBearAttack(time, player, bear));

        EnemyBear bearChar = bear.GetComponent<EnemyBear>();
        bearChar.SetInstance((int)bearHealth, BASEDAMAGE, RELOADTIME, bearWeapon);
        bearChar.Attack();
        bear.transform.up = Vector3.up;
        bear.GetComponent<AIMovement>().SetObject(player);

        return bear;
    }

    public void SetBearPrefab(GameObject bearPrefab)
    {
        this.bearPrefab = bearPrefab;
    }

    private IWEAPON CreateNewBearAttack(float time, GameObject player, GameObject bear)
    {
        float bearDamage = BASEDAMAGE + time * DAMAGEMOD;

        return new AttackTarget(MELEERANGE, (int)bearDamage, player, bear);
    }

}

