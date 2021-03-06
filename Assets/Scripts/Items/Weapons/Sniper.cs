﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class Sniper : Weapon
{

    void Start()
    {
        this.name = "Sniper";
        this.maxDistance = Mathf.Infinity;
        this.damage = 60f;
        this.magazineSize = 5f;
        this.AmmoType = "762mmAmmo"; //Don't think this is used anywhere or needed
        this.reloadTime = 4f;
        this.currentAmmoInMagazine = magazineSize;
        //this.reserveAmmo = inventory.total762mmAmmo;
        this.recoilAmount = 27.5f;
        this.fireTime = 3f;
        //Define attackAnim;
        //Define reloadAnim;
        //Define attackAudio;
        //Define reloadAudio;
    }

    private void Awake()
    {
        this.gameObject.tag = "CanPickup";
        this.gameObject.AddComponent<AudioSource>();
        this.attackSource = this.gameObject.GetComponent<AudioSource>();
        this.attackSource.clip = Resources.Load<AudioClip>(attackAudioName);
        this.attackSource.playOnAwake = false;
    }

    //public Sniper(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    //{
    //    this.name = name;
    //    this.position = position;
    //    this.useableByPlayer = useableByPlayer;
    //}

}
