using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPackSmall : Item
{
    float healthAmount = 25;

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
