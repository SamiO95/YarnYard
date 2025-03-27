using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWEAPON 
{
    public delegate void AttackDeligate();
    public event AttackDeligate AttackEvent;
    public delegate void DamageDeligate(int damage);
    public event DamageDeligate DamageEvent;
    public delegate void CooldownDeligate();
    public event CooldownDeligate AttackCooldownEvent;
    public void Attack(int damage);
}
