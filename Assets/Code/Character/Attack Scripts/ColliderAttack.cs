using UnityEngine;

public class ColliderAttack : MonoBehaviour, IDODAMAGE
{
    private int damage = 0;

    public void SetDamage(int damage) 
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ITAKEDAMAGE>()?.TakeDamage(damage);
    }

}
