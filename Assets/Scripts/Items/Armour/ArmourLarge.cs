﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArmourLarge : Armour
{
    void Start()
    {
        this.armourAmount = 75f;
        this.description = "Medium Armour";
    }

    private void Awake()
    {
        this.gameObject.tag = "CanPickup";
    }

    public ArmourLarge(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.itemName = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }
}
