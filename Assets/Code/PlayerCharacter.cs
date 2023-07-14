using System;

public class PlayerCharacter: AttackingCharacter
{ 
    public event EventHandler PlayerDeathEvent;

    PlayerCharacter(int health, int baseDamage, float reloadTimer, IWEAPON startingWeapon) : base(health, baseDamage, reloadTimer, startingWeapon)
    {}

    protected override void Die() 
    {
        if (gameObject != null) 
        {
            PlayerDeathEvent?.Invoke(this, System.EventArgs.Empty);
        }
    }
}
