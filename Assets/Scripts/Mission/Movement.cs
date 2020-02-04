using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using System;

public class Movement: Mission
{

    bool pressedW, pressedS, pressedA, pressedD, pressedSpace, pressedCtrl = false;

    void Start()
    {
        this.name = "MovementTutorial";
        this.description = "Move using W,S,A,D, SPACE and CTRL";
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { pressedW = true; }
        if (Input.GetKeyDown(KeyCode.S)) { pressedS = true; }
        if (Input.GetKeyDown(KeyCode.A)) { pressedA = true; }
        if (Input.GetKeyDown(KeyCode.D)) { pressedD = true; }
        if (Input.GetKeyDown(KeyCode.Space)) { pressedSpace = true; }
        if (Input.GetKeyDown(KeyCode.Ctrl)) { pressedCtrl = true; }
    }

    void CheckIfFinished()
    {
        if (pressedW == true && pressedS == true && pressedA == true && pressedD == true && pressedSpace == true && pressedCtrl == true)
        {
            this.missionCompleted = true;
        }
    }

}
