using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AmmoLarge : Item
{
    
    void Start()
    {
        this.amount = 75f;
        this.description = "Large Ammo";
    }

    public AmmoLarge(string name, Vector3 position, float amount) : base(name, position, useableByPlayer)
    {
        this.name = name;
        this.position = position;
        this.amount = amount;
    }

    void Update() //Can do this as the inherited class also has Update???
    {
        PickupItem();
    }

    void PickupItem()
    {
        if (this.playerInteract)
        {

            if (this.name == "Large9mmAmmo") { Inventory.total9mmAmmo += this.amount; }
            if (this.name == "Large556mmAmmo") { Inventory.total556mmAmmo += this.amount; }
            if (this.name == "Large762mmAmmo") { Inventory.total762mmAmmo += this.amount; }
            if (this.name == "Large357mmAmmo") { Inventory.total357mmAmmo += this.amount; }
            //Play pickup sound
            Object.Destroy(this.gameObject);

        }
    }

}
