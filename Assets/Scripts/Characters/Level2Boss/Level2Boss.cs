using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Boss : Enemy
{
    void Start()
    {        
        this.maxHealth = 15;
        this.movementSpeed = 12f;
        //this.weapon = new Weapon Hands (); //need to refrence hands as it does not currenly exist?
        Hand handsWeapon = new Hand("Hand", this.transform.position, false);
        this.fovAngle = 90f;
        this.viewDistance = 20f;      
    }
    
}
