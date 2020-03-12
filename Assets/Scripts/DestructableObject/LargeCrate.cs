using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCrate : DestructableObject
{

    void Start()
    {
        this.maxHealth = 200f;
        this.currentHealth = maxHealth;
        this.name = "LargeCrate";
    }

    public LargeCrate(Vector3 position, Item containingItem)
    {
        this.position = position;
        this.containingInside = containingItem;
    }

}


