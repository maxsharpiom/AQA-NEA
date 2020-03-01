﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AmmoMedium : Ammo
{
    
    void Start()
    {
        this.amount = 50f;
        this.description = "Medium Ammo";
    }

    public AmmoMedium(string name, Vector3 position, float amount) : base(name, position, amount)
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

            if (this.name == "Medium9mmAmmo") { inventory.total9mmAmmo += this.amount; }
            if (this.name == "Medium556mmAmmo") { inventory.total556mmAmmo += this.amount; }
            if (this.name == "Medium762mmAmmo") { inventory.total762mmAmmo += this.amount; }
            if (this.name == "Medium357mmAmmo") { inventory.total357mmAmmo += this.amount; }
            //Play pickup sound
            Destroy(this.gameObject);

        }
    }

}
