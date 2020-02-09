using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Armour : Item
{
    protected float armourAmount;
    protected AudioSource pickupSound;

    public Armour(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.itemName = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
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
