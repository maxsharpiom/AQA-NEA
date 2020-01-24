using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Armour : Item
{
    protected float armourAmount;

    void Start()
    {
        this.interactRadius = 0.5f;
    }

    void Update()
    {
        CheckPickup();
    }

    void CheckPickup()
    {
        if (itemIsInInteractableRange)
        {
            //check if the user runs over it and if so, apply health
            this.player.ApplyArmour(healthAmount);
        }
    }


}
