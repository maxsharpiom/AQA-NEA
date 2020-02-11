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
    public bool missionInProgress = false;
    protected Mission previousMission;
    
    //public Mission(string name, string description)
    //{
    //    this.name = name;
    //    this.description = description;
    //}

    void MissionCompleteCondition()
    {
        this.missionInProgress = true;
    }

    void SetActive()
    {
        this.missionInProgress = true;
        Update(); //I want to reference the update in the inherited class
        //May have to do it in each class
    }
}

























//https://answers.unity.com/questions/532244/missionsquests-best-way.html