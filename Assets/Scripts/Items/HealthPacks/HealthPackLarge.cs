using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPackLarge : HealthPack
{
    float healthAmount = 75;

    public HealthPackSmall(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.itemName = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }
}
