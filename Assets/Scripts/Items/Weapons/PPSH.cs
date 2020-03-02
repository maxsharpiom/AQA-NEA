using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class PPSH : Weapon
{

    void Start()
    {
        this.name = "PPSH";
        this.maxDistance = Mathf.Infinity;
        this.damage = 15f;
        this.magazineSize = 35f;
        this.AmmoType = "762mmAmmoTokarev";
        this.reloadTime = 2.5f;
        this.currentAmmoInMagazine = magazineSize;
        this.reserveAmmo = inventory.total9mmAmmo;
        this.recoilAmount = 5f;
        this.fireTime = 0.06315789473f; // 60/950
        //Define attackAnim;
        //Define reloadAnim;
        //Define attackAudio;
        //Define reloadAudio;
    }  
    
    public PPSH(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.name = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }

}
