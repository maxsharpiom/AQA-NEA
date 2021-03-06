﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPack : Item
{
    protected float healthAmount;

    void Start()
    {
        this.interactRadius = 0.5f;
        this.useableByPlayer = true;
    }

    void Update()
    {

    }

    public HealthPack(string name, Vector3 position, bool useableByPlayer)  
    {
        this.position = position;
        this.itemName = name;
        this.useableByPlayer = useableByPlayer;
    }

}
