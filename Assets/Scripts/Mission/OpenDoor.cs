using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using System;

public class OpenDoor : Mission
{
    void Awake()
    {
        gameObject Door = gameObject.FindWithTag("OpenDoorTutorial");
    }

    void Start()
    {
        this.name = "OpenDoorTutorial";
        this.description = "Open the door using your keypass to enter the building";
    }

    void Update()
    {
        CheckIfFinished();
    }

    void CheckIfFinished()
    {
        if (Door.doorOpen == true)
        {
            this.missionCompleted = true;
        }
    }

}
