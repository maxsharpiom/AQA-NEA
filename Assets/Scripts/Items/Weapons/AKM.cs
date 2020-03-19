using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class AKM : Weapon
{

    void Awake()
    {
        this.name = "AKM";
        this.maxDistance = Mathf.Infinity;
        this.damage = 30f;
        this.magazineSize = 31f;
        //this.AmmoType = "762mmAmmo"; //Don't think this is used anywhere or needed
        //this.reloadTime = 3.5f;
        this.currentAmmoInMagazine = magazineSize;
        //this.reserveAmmo = inventory.total762mmAmmo;
        //this.recoilAmount = 15f;
        this.fireTime = 0.096f;        
        //Define attackAnim;
        //Define reloadAnim;
        //Define attackAudio;
        //Define reloadAudio;     
        this.gameObject.tag = "CanPickup";

        //public AKM(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
        //{
        //    this.name = name;
        //    this.position = position;
        //    this.useableByPlayer = useableByPlayer;
        //}

    }
}
