using System.Collections;
using System.Collections.Generic;

public class Character: ITAKEDAMAGE
{
    private readonly int DEAD = 0;
    private int health;

    public Character(int health) 
    {
        this.health = health;
    }

    public void takeDamage(int damage) 
    {
        if ((health - damage) <= DEAD) 
        {
            health = DEAD;

            die();
        }

        health -= damage;       
    }

    protected virtual void die(){}
}
