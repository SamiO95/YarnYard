using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private readonly int DEAD = 0;
    private int health;
    
    

    Character(int health) 
    {
        this.health = health;
    }

    private void takeDamage(int damage) 
    {
        if ((health - damage) < DEAD) 
        {
            health = DEAD;
        }

        
    }


}
