using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ammo : Item
{
    string name;
    float amount;
    Vector3 position;
    public GameObject Player;

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
        if (Physics.CheckSpere(gameObject.transform.position, pickupRadius, /*player layer mask*/))
        {

        }
    }

}
