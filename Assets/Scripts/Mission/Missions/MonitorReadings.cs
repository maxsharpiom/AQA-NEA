using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using System;

public class MonitorReadings : Mission
{

    public MonitorReadings()
    {
        this.name = "Monitor The System";
        this.description = "Take readings from the computer";
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
        
            //this.missionCompleted = true;       
    }

}
