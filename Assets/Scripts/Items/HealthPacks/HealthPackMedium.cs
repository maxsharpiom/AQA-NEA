using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthPackMedium : HealthPack
{
    void Start()
    {
        this.healthAmount = 50f;
        this.description = "Medium Health Pack";
    }

    private void Awake()
    {
        this.gameObject.tag = "CanPickup";
    }

    public HealthPackMedium(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.itemName = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }
}
