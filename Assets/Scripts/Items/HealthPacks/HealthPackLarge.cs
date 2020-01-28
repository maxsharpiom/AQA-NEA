using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPackLarge : HealthPack
{

    void Start()
    {
        this.healthAmount = 75f;
        this.description = "Large Health Pack";
    }

    public HealthPackLarge(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.itemName = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }
}
