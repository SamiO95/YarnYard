using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBear : MonoBehaviour, ICREATE
{
    [SerializeField]
    GameObject bearPrefab;

    private readonly int BASEHEALTH = 10; 
    private readonly int BASEDAMAGE = 10;
    private readonly float MELEERANGE = 5f;
    private readonly float MOVEMENTSPEED = 0.3f;


    public List<GameObject> Create()
    { 
        GameObject bear = Instantiate(bearPrefab);
        bear.transform.up = Vector3.up;

        float bearHealth = BASEHEALTH;
        float bearDamage = BASEDAMAGE;
        List<IWEAPON> bearAttacks = new () { CreateNewBearAttack(gameObject, bear) };

        EnemyCharacter bearChar = bear.GetComponent<EnemyCharacter>();
        bearChar.SetEnemyHealth((int)bearHealth);
        bearChar.SetEnemyMaxHealth((int)bearHealth);
        bearChar.AddEnemyBehaviour(new AttackBehaviour((int)bearDamage, bearAttacks));

        AIMovement bearMovement = bear.GetComponent<AIMovement>();
        bearMovement.SetObject(gameObject);
        bearMovement.SetMovementSpeed(MOVEMENTSPEED);
        bearChar.AddEnemyBehaviour(bearMovement);

        List<GameObject> bears = new () { bear };

        return bears;
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

