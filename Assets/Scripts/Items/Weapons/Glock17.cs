using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class Glock17 : Weapon
{

    void Start()
    {
        this.name = "Glock17";
        this.maxDistance = Mathf.Infinity;
        this.damage = 15f;
        this.magazineSize = 10f;
        this.AmmoType = "9mmAmmo"; //Don't think this is used anywhere or needed
        this.reloadTime = 2.5f;
        this.currentAmmoInMagazine = magazineSize;
        this.reserveAmmo = inventory.total9mmAmmo;        
        this.recoilAmount = 5f;
        this.fireTime = 0.5f;
        //Define attackAnim;
        //Define reloadAnim;
        //Define attackAudio;
        //Define reloadAudio;
    }  
    
    public Glock17(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.name = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }

}
