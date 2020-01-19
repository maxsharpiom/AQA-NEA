using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPackSmall : Item
{
    float healthAmount = 25;

    public HealthPackSmall(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {

    }

    void Start()
    {
        this.interactRadius = 0.5f;
    }

    void PickUp()
    {
        if (itemIsInInteractableRange)
        {
            //check if the user runs over it and if so, apply health
        }
    }

}
