using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using System;

public class OpenDoor : Mission
{
    Door door; //A reference to the gamobject used for the door -- Not linked to a GameObject though?

    void Awake()
    {        
        // door = GameObject.FindWithTag("OpenDoorTutorial");
    }

    public OpenDoor()
    {
        this.name = "Open The Door";
        this.description = "Open the door using your keypass to enter the room";
    }

    void Update()
    {
        if (this.missionInProgress == true)
        {            
            CheckIfFinished();
        }
    }

    void CheckIfFinished()
    {
        if (door.doorOpen == true)
        {
            this.missionCompleted = true;
        }
    }

}
