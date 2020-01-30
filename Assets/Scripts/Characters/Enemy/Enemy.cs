using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AICharacter
{
    public virtual void Start()
    {
        this.friendly = false;
    }
    void Update()
    {
        //ScanFOV();
        //Detect player
    }
}