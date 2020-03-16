using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class M4 : Weapon
{

    void Start()
    {
        this.name = "M4";
        this.maxDistance = Mathf.Infinity;
        this.damage = 25f;
        this.magazineSize = 31f;
        this.AmmoType = "556mmAmmo"; //Don't think this is used anywhere or needed
        this.reloadTime = 3.5f;
        this.currentAmmoInMagazine = magazineSize;
       // this.reserveAmmo = inventory.total556mmAmmo;
        this.recoilAmount = 10f;
        this.fireTime = 0.086f;        
        //Define attackAnim;
        //Define reloadAnim;
        //Define attackAudio;
        //Define reloadAudio;
    }

    private void Awake()
    {
        this.gameObject.tag = "CanPickup";
    }

    //public M4(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    //{
    //    this.name = name;
    //    this.position = position;
    //    this.useableByPlayer = useableByPlayer;
    //}

}
