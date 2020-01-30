using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveWorker : Enemy
{
    public override void Start()
    {
        this.friendly = false;
        this.maxHealth = 20;
        this.movementSpeed = 4f;
        //this.weapon = new Weapon Hands (); //need to refrence hands as it does not currenly exist?
        //Hand handsWeapon = new Hand("Hand", this.transform.position, false);
        //this.fovAngle = 90f;
        this.viewDistance = 20f;
    }

}
