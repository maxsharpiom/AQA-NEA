using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    protected bool dead;
    protected float currentHealth;
    protected float maximumHealth;
    protected float currentArmour;
    protected float maximumArmour;
    GameObject player;

    void Start()
    {
        dead = false;
        player = GameObject.Find("Player");        
    }

    void Update()
    {
        this.currentHealth = player.currentHealth;
        this.currentArmour = player.currentArmour;
        this.maximumHealth = player.maximumHealth;
        this.maximumArmour = player.maximumArmour;
    }

    public void TakeDamage(float damageAmountToApply)
    {
        if (currentArmour > 0)
        {
            currentArmour -= damageAmountToApply;
            if (currentArmour < 0)
            {
                currentHealth + currentArmour;
                currentArmour = 0;
            }
        }
        else if (currentArmour <= 0)
        {
            currentHealth -= damageAmountToApply;
        }         
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        //Drop current weapon
        //Player death anim
        //Destory game object
        Object.Destroy(this.gameObject);
        dead = true;
    }
}
