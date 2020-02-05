using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mission : MonoBehaviour
{
    protected string name;
    protected string description;
    protected bool playerCanSee;
    protected bool missionCompleted;
    protected bool missionInProgress;
    protected Mission previousMission;

    public Mission(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    void virtual MissionCompleteCondition(string missionName)
    {

    }

    void GetCurrentMission()
    {

    }

    void GetNewMission()
    {

    }
    
    void DisplayMission()
    {
        //Display mission Description using canvas
        //https://docs.unity3d.com/2018.2/Documentation/ScriptReference/UI.Text-text.html
    }

    void ActivateNextMission()
    {

    }

}

























//https://answers.unity.com/questions/532244/missionsquests-best-way.html