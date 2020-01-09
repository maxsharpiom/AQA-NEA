using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public Inventory()
    {
        MyList<Items> InventoryList = new MyList<Items>();
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

    bool WeaponExistsInInventory(Item item)
    {
        return InventoryList.Contains(item);                
    }

}
