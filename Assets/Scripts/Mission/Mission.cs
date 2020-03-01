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
    
    public string Description
    {
        get { return description; }
        set { Description = value; }
    }

    public bool MissionCompleted
    {
        get { return missionCompleted; }
        set { MissionCompleted = value; }
    }

    //public Mission(string name, string description)
    //{
    //    this.name = name;
    //    this.description = description;
    //}

    void MissionCompleteCondition()
    {
        this.missionInProgress = true;
    }

    public void SetActive()
    {
        this.missionInProgress = true;
        Update(); //I want to reference the update in the inherited class
        //May have to do it in each class
    }

    //Checking if the player meets the conditions
    void Update()
    {
        while (this.missionInProgress == true)
        {
            CheckingMission();
            CheckIfFinished();
        }
    }

    public virtual void CheckingMission()
    {
       
    }

    public virtual void CheckIfFinished()
    {

    }
}

























//https://answers.unity.com/questions/532244/missionsquests-best-way.html