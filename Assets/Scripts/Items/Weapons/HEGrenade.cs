using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static System.Math;

public class HEGrenade : Weapon
{
    
    void Start()
    {
        this.name = "HEGrenade";
        this.maxDistance = Mathf.Infinity;
        this.damage = 80f;
        this.firetime = 2f;
        this.recoilAmount = 0f;
        //Define attackAnim;
        //Define reloadAnim;
        //Define attackAudio;
        //Define reloadAudio;
    }  
    
    //public HEGrenade(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    //{
    //    this.name = name;
    //    this.position = position;
    //    this.useableByPlayer = useableByPlayer;
    //}

    void Explode()
    {

    }

}
