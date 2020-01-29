using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveWolf : Enemy
{
    public override void Start()
    {
        base.Start();
        this.maxHealth = 15;
        this.movementSpeed = 12f;
        //this.weapon = new Weapon Hands (); //need to refrence hands as it does not currenly exist?
        Hand handsWeapon = new Hand("Teeth", this.transform.position, false);
        //this.fovAngle = 90f;
        this.viewDistance = 20f;      
    }
    
}
