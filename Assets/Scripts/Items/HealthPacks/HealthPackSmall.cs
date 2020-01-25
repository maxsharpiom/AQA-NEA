using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPackSmall : HealthPack
{
    float healthAmount = 25;

    public HealthPackSmall(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.itemName = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }
}
