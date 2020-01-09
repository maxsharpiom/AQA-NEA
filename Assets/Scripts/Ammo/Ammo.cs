using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ammo 
{
    string name;
    float amount;
    Vector3 position;
    public GameObject Player;
    LayerMask playerLayerMask = 10;

    public Ammo(string name, Vector3 position, float amount)
    {
        this.name = name;
        this.position = position;
        this.amount = amount;
    }

    void Update()
    {
        PickUp();
    }

    void PickUp()
    {
        float pickupRadius = 0.5f;
        //If the player is within the radius of the ammo pack
        if (Physics.CheckSphere(position, pickupRadius, 10/*player layer mask*/))
        {
            //Check if the player has the weapon for this ammo type (stored in a list in inventory)
            if (Inventory.WeaponExistsInInventory())
            {

            }
            //If the player has the correct weapon then add ammo to the weapon
        }
    }

}
