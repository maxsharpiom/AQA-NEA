using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCrate : DestructableObject
{

    void Start()
    {
        this.maxHealth = 20f;
        this.currentHealth = maxHealth;
        this.name = "SmallCrate";
    }

    public SmallCrate(Vector3 position, Item containingItem)
    {
        this.position = position;
        this.containingInside = containingItem;
    }

}


