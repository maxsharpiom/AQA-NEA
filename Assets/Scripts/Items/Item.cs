using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using System;

public class Item : MonoBehaviour
{
    protected string itemName;
    protected bool usableByPlayer;
    protected Vector3 position;
    protected string description;
    protected Animation equipAnimation;
    protected float interactRadius;
    public float DistanceBetweenPlayerAndItem;
    protected GameObject player = GameObject.Find("Player");
    protected bool itemIsInInteractableRange;

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
        DistanceBetweenPlayerAndItem = FindDistanceBetweenPlayerAndItem();
        FindIfItemIsInInteractableRange();
    }

    void FindIfItemIsInInteractableRange()
    {
        if (DistanceBetweenPlayerAndItem < interactRadius)
        {
            itemIsInInteractableRange = true;
        }
        else
        {
            itemIsInInteractableRange = false;
        }
    }

    void FindDistanceBetweenPlayerAndItem() //May or may not need to pass variables to work
    {
        //do pythag
        DistanceBetweenPlayerAndItem = Mathf.Sqrt(Mathf.Pow(player.transform.position.x - position.x, 2) + Mathf.Pow(player.transform.position.z - player.transform.position.z, 2));

        return DistanceBetweenPlayerAndItem;
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
        //if (Physics.CheckSphere(position, interactRadius, playerLayerMask))
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
