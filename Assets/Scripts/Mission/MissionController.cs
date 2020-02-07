using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MissionController : MonoBehaviour
{
    /// (0) Arrive on underground tram to set scene
    /// (2) Movement tutorial
    /// () Open door to area
    /// (1) Approach nuclear system and interact
    /// ** LOAD NEXT LEVEL - EXPLODES **
    /// (3) Pickup crowbar (any generic weapon really) -- pickup game hint
    /// (3) Protect scientist while enemies around
    /// (4) Kill radioactive workers to complete level
    /// (5) Destroy barrier / destructable objects
    /// (6) Move objects around to climb level (utilise pickup) **Scientist left behind**
    /// (7) Face level 1 boss
    /// (8) Move objects around to reach ground level (utilise pickup)
    /// (9) Find scientist to help you access the ground level
    /// ** OPEN DOOR **
    /// (10) Kill all ground troops and face level 2 boss
    /// --> Opportunity for differnt path (should have two differnt options)
    ///     ## Once a path has been chosen (a corridoor), level loaded and locked out of other path
    /// A)
    ///     Find some sort of cure (Time machine?)
    ///     While waiting for cure to take effect kill reinforcements and protect working scientist
    ///     ** GET IN MACHINE **
    ///     Arrive back at scene (0 or 1) and game ends
    /// B) Game ends with no cure
    /// (11) Reach gate door to end game

    //A list used to represent the player's missions
    MyList<Mission> MissionList = new MyList<Mission>();
    protected string name;
    protected string description;
    protected bool playerCanSee;
    protected bool missionCompleted;
    protected bool missionInProgress;
    protected Mission previousMission;
    protected Mission currentMission;
    protected Mission NextMission;
    /// <summary>
    /// The player camera
    /// </summary>
    protected Camera playerCamera;

    void CompleteMission(string missionName)
    {

    }

    void GetCurrentMission()
    {

    }

    void GetNewMission()
    {
        NextMission = MissionList.Next(currentMission);
    }
    
    void DisplayMission()
    {
        //Display mission Description using canvas
        //https://docs.unity3d.com/2018.2/Documentation/ScriptReference/UI.Text-text.html
    }

    void ActivateNextMission()
    {

    }
    
    //https://docs.unity3d.com/ScriptReference/GUI.Label.html
    public virtual OnGUI(string TextToDisplay)
    {
        float yOffsetFromPlayerCameraForward = -50f;
        //(xpos, ypos, width, height) all as float values
        GUI.Label(new Rect(playerCamera.transform.forward.x, playerCamera.transform.forward.y+yOffsetFromPlayerCameraForward, 200,200), TextToDisplay); 
    }

}

























//https://answers.unity.com/questions/532244/missionsquests-best-way.html