using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class Mosin : Weapon
{

    void Start()
    {
        this.name = "Mosin";
        this.maxDistance = Mathf.Infinity;
        this.damage = 40f;
        this.magazineSize = 10f;
        this.AmmoType = "762mmAmmo"; //Don't think this is used anywhere or needed
        this.reloadTime = 4f;
        this.currentAmmoInMagazine = magazineSize;
        //this.reserveAmmo = inventory.total762mmAmmo;
        this.recoilAmount = 20f;
        this.fireTime = 2.5f;
        //Define attackAnim;
        //Define reloadAnim;
        //Define attackAudio;
        //Define reloadAudio;
    }  
    
    //public Mosin(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    //{
    //    this.name = name;
    //    this.position = position;
    //    this.useableByPlayer = useableByPlayer;
    //}

}
