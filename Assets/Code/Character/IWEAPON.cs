using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWEAPON 
{
    public delegate void AttackDeligate();
    public delegate void DamageDeligate(int damage);
    public event AttackDeligate AttackEvent;
    public event DamageDeligate DamageEvent;
    public event AttackDeligate AttackCooldownEvent;
    public void Attack(int damage);
}
