using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    private string name;
    private bool usableByPlayer;
    private Vector3 position;    
    private string description;
    private Animation equipAnimation;
    protected float pickupRadius = 0.5f;

    /// <summary>
    /// Sets the position of the item in the game world
    /// </summary>
    /// <param name="position"></param>
    public Item(string name, Vector3 position, bool useableByPlayer)
    {
        this.position = position;
        this.name = name;
        this.usableByPlayer = useableByPlayer;
    }

    void Update()
    {
        PickUp();
    }

    /// <summary>
    /// Add an item to the player's inventory
    /// Should not be responsible for the validation of weather or not the weapon
    /// is already in the player's inventory
    /// </summary>
    void PickUp()
    {
        //  (1) Add item to the player's inventory
        //  (2) Remove item from gameWorld


        //If the player is within the radius of the ammo pack
        //if (Physics.CheckSphere(position, pickupRadius, playerLayerMask))
        //{

        //    //Is the item already in the player's inventory?
        //    if ()
        //    {

        //    }

        //    ////Check if the player has the weapon for this ammo type (stored in a list in inventory)
        //    //if (Inventory.WeaponExistsInInventory())
        //    //{

        //    //}
        //    ////If the player has the correct weapon then add ammo to the weapon
        //}
    }

}
