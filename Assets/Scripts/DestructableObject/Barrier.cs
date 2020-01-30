using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : DestructableObject
{

    void Start()
    {        
        this.name = "Barrier";
    }

    public MediumCrate(Vector3 position, float maxHealth)
    {
        this.position = position;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

}


