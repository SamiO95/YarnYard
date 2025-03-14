using System;
using UnityEngine;

public interface ITAKEDAMAGE
{
    GameObject GetDamagableCharacter();
    void TakeDamage(int damage);
    void SetTimer(float time, Action timerAction);
}
