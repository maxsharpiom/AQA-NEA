using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPackSmall : HealthPack
{

    void Start()
    {
        this.healthAmount = 25f;
        this.description = "Small Health Pack";
    }

    private void Awake()
    {
        this.gameObject.tag = "CanPickup";
    }

    public HealthPackSmall(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.itemName = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }
}
