using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ammo : Item
{
    protected float amount;
    //public GameObject Player;
    LayerMask playerLayerMask = LayerMask.GetMask("Player");
    bool playerHasAmmoType; //must set true when a weapon of the correct ammo type is picked up
    private static bool useableByPlayer;
    protected string AmmoType;
    protected AudioSource pickupSound;

    //public Ammo(string name, Vector3 position, float amount) : base(name, position, useableByPlayer)
    //{
    //    this.name = name;
    //    this.position = position;
    //    this.amount = amount;
    //}

}
