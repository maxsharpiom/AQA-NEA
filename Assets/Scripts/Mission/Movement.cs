using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using System;

public class Movement: Mission
{

    bool pressedW, pressedS, pressedA, pressedD, pressedSpace, pressedCtrl = false;        

    public Movement()
    {
        this.name = "Move";
        this.description = "Move using W,S,A,D, SPACE and CTRL";
        DisplayMission();
    }
    
    //Checking if the player meets the conditions
    void Update()
    {        
        if (this.missionInProgress == true)
        {
            CheckingMission();
            CheckIfFinished();
        }
    }

    //void set(string status)
    //{
    //    this.missionInProgress = true;        
    //}

    void CheckingMission()
    {
        if (Input.GetKeyDown(KeyCode.W)) { pressedW = true; }
        if (Input.GetKeyDown(KeyCode.S)) { pressedS = true; }
        if (Input.GetKeyDown(KeyCode.A)) { pressedA = true; }
        if (Input.GetKeyDown(KeyCode.D)) { pressedD = true; }
        if (Input.GetKeyDown(KeyCode.Space)) { pressedSpace = true; }
        if (Input.GetKeyDown(KeyCode.Ctrl)) { pressedCtrl = true; } //crouching not yet implemented though
    }

    void CheckIfFinished()
    {
        if (pressedW == true && pressedS == true && pressedA == true && pressedD == true && pressedSpace == true && pressedCtrl == true)
        {
            this.missionCompleted = true;
        }
    }
}