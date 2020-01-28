using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Armour : Item
{
    protected float armourAmount;
    protected AudioSource pickupSound;

    void Start()
    {
        this.interactRadius = 0.5f;
        this.useableByPlayer = true;
    }

    void Update()
    {
        PickupItem();
    }

    void PickupItem()
    {
        if (this.playerInteract)
        {
            //Apply armour
            this.player.currentArmour += this.armourAmount;
            if (this.player.currentArmour > this.player.maxArmour)
            {
                this.player.currentArmour = this.player.maxArmour;
            }
            //Play sound
            //Destroy gameobject
            Object.Destroy(this.gameObject);
        }
    }

}
