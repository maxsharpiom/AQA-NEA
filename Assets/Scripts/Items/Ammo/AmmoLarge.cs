using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AmmoLarge : Ammo
{
    
    void Start()
    {
        this.amount = 75f;
        this.description = "Large Ammo";
    }

    public AmmoLarge(string name, Vector3 position, float amount) : base(name, position, amount)
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

            if (this.name == "Large9mmAmmo") { inventory.total9mmAmmo += this.amount; }
            if (this.name == "Large556mmAmmo") { inventory.total556mmAmmo += this.amount; }
            if (this.name == "Large762mmAmmo") { inventory.total762mmAmmo += this.amount; }
            if (this.name == "Large357mmAmmo") { inventory.total357mmAmmo += this.amount; }
            //Play pickup sound
            Destroy(this.gameObject);

        }
    }

}
