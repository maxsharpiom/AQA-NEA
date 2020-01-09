using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioactiveWorker : Enemy
{

    void Start()
    {
        Hand 
        this.maxHealth = 20;
        this.movementSpeed = 4f;
        this.weapon = new Hands Hand; //need to refrence hands as it does not currenly exist?
        this.fovAngle = 90f;
        this.viewDistance = 20f;
    }
    
}
