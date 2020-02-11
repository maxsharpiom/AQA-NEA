using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using System;

public class OpenDoor : Mission
{
    void Awake()
    {
        //A reference to the gamobject used for the door
        gameObject Door = gameObject.FindWithTag("OpenDoorTutorial");
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
        if (Door.doorOpen == true)
        {
            this.missionCompleted = true;
        }
    }

}
