using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    string name;
    bool usableByPlayer;
    Vector3 position;
    //May not need
    string description;

    /// <summary>
    /// Sets the position of the item in the game world
    /// </summary>
    /// <param name="position"></param>
    public Item(Vector3 position)
    {
        this.position = position;
    }

}
