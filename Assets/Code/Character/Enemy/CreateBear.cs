using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBear : MonoBehaviour, ICREATE
{
    [SerializeField]
    GameObject bearPrefab;

    private readonly int BASEHEALTH = 10; 
    private readonly float HEALTHMOD = 10.1f;
    private readonly int BASEDAMAGE = 10;
    private readonly float DAMAGEMOD = 10.1f;
    private readonly float MELEERANGE = 5f;
    private readonly float MOVEMENTSPEED = 0.3f;


    public GameObject Create(float time, GameObject player)
    { 
        GameObject bear = Instantiate(bearPrefab);
        bear.transform.up = Vector3.up;

        float bearHealth = BASEHEALTH + time * HEALTHMOD;
        float bearDamage = BASEDAMAGE + time * DAMAGEMOD;
        List<IWEAPON> bearAttacks = new List<IWEAPON>();
        bearAttacks.Add(CreateNewBearAttack(player, bear));

        EnemyCharacter bearChar = bear.GetComponent<EnemyCharacter>();
        bearChar.SetEnemyHealth((int)bearHealth);
        bearChar.SetEnemyMaxHealth((int)bearHealth);
        bearChar.AddEnemyBehaviour(new AttackBehaviour((int)bearDamage, bearAttacks));

        AIMovement bearMovement = bear.GetComponent<AIMovement>();
        bearMovement.SetObject(player);
        bearMovement.SetMovementSpeed(MOVEMENTSPEED);
        bearChar.AddEnemyBehaviour(bearMovement);
        
        return bear;
    }

    public void SetBearPrefab(GameObject bearPrefab)
    {
        this.bearPrefab = bearPrefab;
    }

    private IWEAPON CreateNewBearAttack(GameObject player, GameObject bear)
    {
        return new AttackTarget(MELEERANGE, player, bear);
    }

}

