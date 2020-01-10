using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class Crowbar : Weapon
{

    void start()
    {
        this.name = "Crowbar";
        this.maxDistance = 1f;
        this.damage = 10f;
        this.magazineSize = Mathf.Infinity;
        this.AmmoType = null;
        this.reloadTime = 0;
        this.currentAmmoInMagazine = Mathf.Infinity;
        this.reserveAmmo = Mathf.Infinity;
        //Define attackAnim;
        //Define reloadAnim;
        //Define attackAudio;
        //Define reloadAudio;
    }    
}
