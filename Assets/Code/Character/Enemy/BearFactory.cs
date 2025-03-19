using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFactory : EnemyFactory
{
    private readonly int BASEMAXHEALTH = 50;
    private readonly int BASEDAMAGE = 1;
    private readonly float BASEMELEERANGE = 5f;
    private readonly float ATTACKCOOLDOWN = 5f;
    private readonly float BASEMOVEMENTSPEED = 0.3f;

    protected override EnemyCharacter ConstructEnemy(EnemyCharacter enemy, IINSTRUCTOR difficultyMaster)
    {
        float difficultyMod = difficultyMaster.GetMod();
        GameObject target = difficultyMaster.GetTargetObject();

        float bearHealth = Random.Range(BASEMAXHEALTH, BASEMAXHEALTH * difficultyMod);
        enemy.SetEnemyMaxHealth((int)bearHealth);
        enemy.SetEnemyHealth((int)bearHealth);
        

        float bearDamage = BASEDAMAGE + Random.Range(BASEDAMAGE, BASEDAMAGE * difficultyMod);
        List<IWEAPON> bearAttacks = new () { CreateNewBearAttack(target, enemy.gameObject) };
        enemy.AddEnemyBehaviour(new AttackBehaviour((int)bearDamage, bearAttacks));

        AIMovement bearMovement = enemy.gameObject.GetComponent<AIMovement>();
        bearMovement.SetTarget(target);
        bearMovement.SetMovementSpeed(BASEMOVEMENTSPEED);
        enemy.AddEnemyBehaviour(bearMovement);

        return enemy;
    }
    private IWEAPON CreateNewBearAttack(GameObject player, GameObject bear)
    {
        return new AttackTarget(BASEMELEERANGE, ATTACKCOOLDOWN, player.GetComponent<ITAKEDAMAGE>(), bear);
    }

}
