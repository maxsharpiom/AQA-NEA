using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class SVD : Weapon
{
    
    void Start()
    {
        this.name = "SVD";
        this.maxDistance = Mathf.Infinity;
        this.damage = 45f;
        this.magazineSize = 20f;
        this.AmmoType = "762mmAmmo"; //Don't think this is used anywhere or needed
        this.reloadTime = 4f;
        this.currentAmmoInMagazine = magazineSize;
        //this.reserveAmmo = inventory.total762mmAmmo;
        this.recoilAmount = 25f;
        this.fireTime = 2f;
        //Define attackAnim;
        //Define reloadAnim;
        //Define attackAudio;
        //Define reloadAudio;
    }

    //public Sniper(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    //{
    //    this.name = name;
    //    this.position = position;
    //    this.useableByPlayer = useableByPlayer;
    //}

}
