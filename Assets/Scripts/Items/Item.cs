using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    public string name;
    public bool usableByPlayer;
    public Vector3 position;    
    public string description;

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

}
