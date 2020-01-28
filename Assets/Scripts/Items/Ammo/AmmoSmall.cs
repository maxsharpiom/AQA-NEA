using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AmmoSmall : Item
{
    
    void Start()
    {
        this.amount = 25f;
        this.description = "Small Ammo";        
    }

    public AmmoSmall(string name, Vector3 position, float amount) : base(name, position, useableByPlayer)
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

            if (this.name == "Small9mmAmmo") { this.total9mmAmmo += this.amount; }
            if (this.name == "Small556mmAmmo"){ this.total556mmAmmo += this.amount; }
            if (this.name == "Small762mmAmmo"){ this.total762mmAmmo += this.amount; }
            //Play pickup sound
            Object.Destroy(this.gameObject);
            
        }
    }

}
