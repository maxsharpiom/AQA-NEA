using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that must be attached to anything that can take damage
/// Some of this script derives from Brakey's youtube video
/// https://www.youtube.com/watch?v=THnivyG0Mvo
/// </summary>
public class Target : MonoBehaviour
{
    public TakeDamage(float amount)
    {
        this.maxHealth -= amount;

        //If the health of the gameObject is less than or equal to zero then the gameObject is destroyed
        if (this.maxHealth <= 0)
        {
            Die();
        }
    }

    //Destroy the gameObject attached to the script
    public Die()
    {
        Destroy(this.gameObject);
        //Play animation associated with the game object death (should be specific to gameObject)        
        //this.gameObject.DieAnim
    }
}
