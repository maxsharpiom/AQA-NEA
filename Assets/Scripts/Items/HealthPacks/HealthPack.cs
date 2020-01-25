using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPack : Item
{
    protected float healthAmount;

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
            this.player.ApplyHealth(healthAmount);
        }
    }


}
