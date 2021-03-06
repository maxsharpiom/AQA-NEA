﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class Revolver: Weapon
{

    void Start()
    {
        this.name = "Revolver";
        this.maxDistance = Mathf.Infinity;
        this.damage = 20f;
        this.magazineSize = 8f;
        this.AmmoType = "357mmAmmo"; //Don't think this is used anywhere or needed
        this.reloadTime = 5f;
        this.currentAmmoInMagazine = magazineSize;
        //this.reserveAmmo = inventory.total357mmAmmo;        
        this.recoilAmount = 15f;
        this.fireTime = 0.75f;
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

    //public Revolver(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    //{
    //    this.name = name;
    //    this.position = position;
    //    this.useableByPlayer = useableByPlayer;
    //}

}
