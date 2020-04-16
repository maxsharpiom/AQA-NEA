using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArmourSmall : Armour
{
    void Start()
    {
        this.armourAmount = 25f;
        this.description = "Small Armour";
        this.interactRadius = 0.5f;
        this.useableByPlayer = true;
    }

    private void Awake()
    {
        this.gameObject.tag = "CanPickup";
    }

    public ArmourSmall(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.itemName = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }
}
