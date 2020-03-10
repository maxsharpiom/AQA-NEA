using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class Teeth : Weapon
{

    void Start()
    {
        this.name = "Teeth";
        this.maxDistance = 0.5f;
        this.damage = 20f;
        this.magazineSize = Mathf.Infinity;
        this.AmmoType = null;
        this.reloadTime = 2f;
        this.currentAmmoInMagazine = Mathf.Infinity;
        this.reserveAmmo = Mathf.Infinity;
        //Define attackAnim;
        //Define reloadAnim;
        //Define attackAudio;
        //Define reloadAudio;
    }  
    
    //public Teeth(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    //{
    //    this.name = name;
    //    this.position = position;
    //    this.useableByPlayer = useableByPlayer;
    //}

}
