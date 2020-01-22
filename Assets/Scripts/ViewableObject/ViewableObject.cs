using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    protected bool dead;
    protected float currentHealth;
    protected float maximumHealth;
    protected 

    public void TakeDamage(float damageAmountToApply)
    {
        currentHealth -= damageAmountToApply;
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
    }
}
