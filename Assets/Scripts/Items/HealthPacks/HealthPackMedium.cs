using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPackMedium : HealthPack
{
    float healthAmount = 50;

    public HealthPackSmall(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.itemName = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }
}
