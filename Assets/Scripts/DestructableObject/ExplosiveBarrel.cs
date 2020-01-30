using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : DestructableObject
{

    void Start()
    {
        this.maxHealth = 20f;
        this.currentHealth = maxHealth;
        this.name = "ExplosiveBarrel";
        this.explodes = true;
        this.containsItem = false;
        this.explosionRadius = 10f;
        this.maximumDamage = 80f;
    }

    public ExplosiveBarrel(Vector3 position)
    {
        this.position = position;
    }

}


