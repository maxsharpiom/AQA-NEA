using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumCrate : DestructableObject
{

    void Start()
    {
        this.maxHealth = 90f;
        this.currentHealth = maxHealth;
        this.name = "MediumCrate";
    }

    public MediumCrate(Vector3 position, Item containingItem)
    {
        this.position = position;
        this.containingInside = containingItem;
    }

}


