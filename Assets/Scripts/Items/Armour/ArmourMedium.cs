﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArmourMedium : Armour
{
    void Start()
    {
        this.armourAmount = 50f;
        this.description = "Medium Armour";
    }

    private void Awake()
    {
        this.gameObject.tag = "CanPickup";
    }

    public ArmourMedium(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.itemName = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }
}
