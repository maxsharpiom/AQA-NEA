﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    //The current item that the player has equiped
    Item currentItem; //Not yet known;
    MyList<Item> InventoryList = new MyList<Item>();
    public float total9mmAmmo;
    public float total556mmAmmo;
    public float total762mmAmmo;
    public float total357mmAmmo;
    public float total762mmAmmoTokarev;

    //public Inventory() //Don't think this is needed right now
    //{

    //}

    /// <summary>
    /// Upon start the current item is the first item in the list
    /// </summary>
    void Start() //May not work if starting game from a saved state as it would reset ammo?
    {        
        currentItem = InventoryList.ReturnObject(1);
        this.total9mmAmmo = 0f;
        this.total556mmAmmo = 0f;
        this.total762mmAmmo = 0f;
        this.total357mmAmmo = 0f;
        this.total762mmAmmoTokarev = 0f;
    }

    void Update()
    {
        SwitchWeapon();
    }

    /// <summary>
    /// Add an item to the player's inventory
    /// </summary>
    /// <param name="item"></param>
    void AddItem(Item item)
    {
        InventoryList.Add(item);
    }

    void RemoveItem(Item item)
    {
        InventoryList.Remove(item);
    }

    void SwapItem(Item newItem, Item itemToSwap)
    {
        InventoryList.ReplaceNode(newItem, itemToSwap);
    }

    void AddAmmo(Item item, int amount)
    {

    }

    void RemoveAmmo(Item item, int amount)
    {

    }

    //public bool AmmoTypeExistsInIventory(Ammo ammo)
    //{

    //}

    public bool ItemExistsInInventory(Item item)
    {
        return InventoryList.Contains(item);
    }

    void SwitchWeapon()
    {
        Item oldItem = currentItem;
        int weaponNumberSelect = 0; //Nothing happens
        if (Input.GetKey(KeyCode.Alpha1)) { weaponNumberSelect = 1; }
        if (Input.GetKey(KeyCode.Alpha2)) { weaponNumberSelect = 2; }
        if (Input.GetKey(KeyCode.Alpha3)) { weaponNumberSelect = 3; }
        if (Input.GetKey(KeyCode.Alpha4)) { weaponNumberSelect = 4; }
        if (Input.GetKey(KeyCode.Alpha5)) { weaponNumberSelect = 5; }
        if (Input.GetKey(KeyCode.Alpha6)) { weaponNumberSelect = 6; }
        if (Input.GetKey(KeyCode.Alpha7)) { weaponNumberSelect = 7; }
        if (Input.GetKey(KeyCode.Alpha8)) { weaponNumberSelect = 8; }
        if (Input.GetKey(KeyCode.Alpha9)) { weaponNumberSelect = 9; }

        //If the current item is not the item selected...
        if (currentItem != InventoryList.ReturnObject(weaponNumberSelect))
        {
            //The item that the player is currently holding is equal to the object that is selected
            currentItem = InventoryList.ReturnObject(weaponNumberSelect);
            //SwapItemToCurrentAndMakeActive(oldItem, currentItem);
        }
        oldItem = currentItem;
    }

    //void SwapItemToCurrentAndMakeActive(Item oldItem, Item newItem)
    //{
    //    //The old item is no longer active
    //    oldItem.SetActive(false);
    //    //New item is now active
    //    newItem.SetActive(true);
    //    //Play newItem equip Anim

    //}

}
