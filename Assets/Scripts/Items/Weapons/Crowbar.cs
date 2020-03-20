using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class Crowbar : Weapon
{

    void Start()
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

    private void Awake()
    {
        this.gameObject.tag = "CanPickup";
        this.gameObject.AddComponent<AudioSource>();
        this.attackSource = this.gameObject.GetComponent<AudioSource>();
        this.attackSource.clip = Resources.Load<AudioClip>(attackAudioName);
        this.attackSource.playOnAwake = false;
    }

    //public Crowbar(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    //{
    //    this.name = name;
    //    this.position = position;
    //    this.useableByPlayer = useableByPlayer;
    //}

}
