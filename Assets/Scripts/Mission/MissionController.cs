//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class MissionController : MonoBehaviour
//{
//    /// (0) Arrive on underground tram to set scene
//    /// (2) Movement tutorial
//    /// () Open door to area
//    /// (1) Approach nuclear system and interact
//    /// ** LOAD NEXT LEVEL - EXPLODES **
//    /// (3) Pickup crowbar (any generic weapon really) -- pickup game hint
//    /// (3) Protect scientist while enemies around
//    /// (4) Kill radioactive workers to complete level
//    /// (5) Destroy barrier / destructable objects
//    /// (6) Move objects around to climb level (utilise pickup) **Scientist left behind**
//    /// (7) Face level 1 boss
//    /// (8) Move objects around to reach ground level (utilise pickup)
//    /// (9) Find scientist to help you access the ground level
//    /// ** OPEN DOOR **
//    /// (10) Kill all ground troops and face level 2 boss
//    /// --> Opportunity for differnt path (should have two differnt options)
//    ///     ## Once a path has been chosen (a corridoor), level loaded and locked out of other path
//    /// A)
//    ///     Find some sort of cure (Time machine?)
//    ///     While waiting for cure to take effect kill reinforcements and protect working scientist
//    ///     ** GET IN MACHINE **
//    ///     Arrive back at scene (0 or 1) and game ends
//    /// B) Game ends with no cure
//    /// (11) Reach gate door to end game

//    //A list used to represent the player's missions
//    MyList<Mission> MissionList = new MyList<Mission>();//Need to add missions to list
//    protected string name;
//    protected string description;
//    protected bool playerCanSee;
//    protected bool missionCompleted;
//    protected bool missionInProgress;
//    protected Mission previousMission;//Made it Node<x> may cause errors
//    protected Mission currentMission;
//    protected Mission NextMission; 
//    protected Camera playerCamera;
    
//    public MissionController()
//    {
//        CreateAndAddMissions();
//    }

//    void Update()
//    {
//        GetCurrentMission();
//    }

//    void CreateAndAddMissions()
//    {
//        //If you instantiate a mission, it will be set to active.
//        Movement movementMission = new Movement(); //inProgess might = true, becuase it has been instantiated
//        MissionList.Add(movementMission);
//        OpenDoor openDoorMission = new OpenDoor();
//        MissionList.Add(openDoorMission);
//    }

//    //void CompleteMission()
//    //{
//    //    if (currentMission.missionCompleted)
//    //    {
//    //        GetNewMission();
//    //    }
//    //}

//    void GetCurrentMission() //Try to convert <T> to T in MyList class
//    {
//        //The current mission is the current pointer in the MissionList
//        currentMission = MissionList.current;
//        //Instantiate the mission in the location to make it active
//        //currentMission.SetActive();
//    }

//    void GetNewMission()
//    {
//        NextMission = MissionList.Next(currentMission);        
//        ActivateNextMission();
//    }
    
//    void DisplayMission()
//    {
//        //Display mission Description using canvas
//        //https://docs.unity3d.com/2018.2/Documentation/ScriptReference/UI.Text-text.html
//        OnGUI(true, currentMission.name);
//        OnGUI(false, currentMission.Description);
//    }

//    void ActivateNextMission()
//    {
//        currentMission = NextMission;
//        DisplayMission(); //May show the next mission and not the current one
//    }
    
//    //https://docs.unity3d.com/ScriptReference/GUI.Label.html
//    void OnGUI(bool missionName, string TextToDisplay)
//    {
//        if (missionName == true)
//        {
//            float yOffsetFromPlayerCameraForward = +50f;
//            //(xpos, ypos, width, height) all as float values
//            GUI.Label(new Rect(playerCamera.transform.forward.x, playerCamera.transform.forward.y + yOffsetFromPlayerCameraForward, 200, 200), TextToDisplay);
//        }
//        else //A description of how to complete the mission
//        {
//            float yOffsetFromPlayerCameraForward = -50f;
//            //(xpos, ypos, width, height) all as float values
//            GUI.Label(new Rect(playerCamera.transform.forward.x, playerCamera.transform.forward.y + yOffsetFromPlayerCameraForward, 200, 200), TextToDisplay);
//        }
//    }

//}

























////https://answers.unity.com/questions/532244/missionsquests-best-way.html