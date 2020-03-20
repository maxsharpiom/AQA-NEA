using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    //The current item that the player has equiped
    public Item currentItem = null; //May not allow access to Item properties
    MyList<Item> InventoryList = new MyList<Item>();
    public float total9mmAmmo;
    public float total556mmAmmo;
    public float total762mmAmmo;
    public float total357mmAmmo;
    public float total762mmAmmoTokarev;
    public Player player;
    int weaponNumberSelect = 1;

    //Equip this item
    public void EquipItem(Item oldItem, Item newItem)
    {       
    }

    /// <summary>
    /// Upon start the current item is the first item in the list
    /// </summary>
    void Awake() //May not work if starting game from a saved state as it would reset ammo?
    {
        //currentItem = InventoryList.ReturnObject(1);
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

    public bool CheckIfItemIsAlReadyInInventory(Item item)
    {
        bool contains = false;

        if (InventoryList.Contains(item))
        {
            contains = true;
        }

        return contains;
    }

    /// <summary>
    /// Add an item to the player's inventory
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
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
    
    public bool ItemExistsInInventory(Item item)
    {
        return InventoryList.Contains(item);
    }

    void SwitchWeapon()
    {
        if (Input.GetKey(KeyCode.Alpha1)) { weaponNumberSelect = 1; }
        if (Input.GetKey(KeyCode.Alpha2)) { weaponNumberSelect = 2; }
        if (Input.GetKey(KeyCode.Alpha3)) { weaponNumberSelect = 3; }
        if (Input.GetKey(KeyCode.Alpha4)) { weaponNumberSelect = 4; }
        if (Input.GetKey(KeyCode.Alpha5)) { weaponNumberSelect = 5; }
        if (Input.GetKey(KeyCode.Alpha6)) { weaponNumberSelect = 6; }
        if (Input.GetKey(KeyCode.Alpha7)) { weaponNumberSelect = 7; }
        if (Input.GetKey(KeyCode.Alpha8)) { weaponNumberSelect = 8; }
        if (Input.GetKey(KeyCode.Alpha9)) { weaponNumberSelect = 9; }

        int counter = 0;

        foreach (Transform item in transform)
        {
            if (counter == weaponNumberSelect - 1)
            {                
                item.gameObject.SetActive(true);
                currentItem = item.gameObject.GetComponent<Item>();
                //player.currentWeapon = item.gameObject.GetComponent<Weapon>();    
            }
            else
            {
                item.gameObject.SetActive(false);
            }

            counter += 1;
        }

        //If the current item is not the item selected...
        //if (currentItem != InventoryList.ReturnObject(weaponNumberSelect))
        //{
        //    //The item that the player is currently holding is equal to the object that is selected
        //    currentItem = InventoryList.ReturnObject(weaponNumberSelect);
        //    //SwapItemToCurrentAndMakeActive(oldItem, currentItem);
        //    //Play swap anim
        //}
        //oldItem = currentItem;
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
