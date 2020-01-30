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
    }

    public ExplosiveBarrel(Vector3 position)
    {
        this.position = position;
    }

}


