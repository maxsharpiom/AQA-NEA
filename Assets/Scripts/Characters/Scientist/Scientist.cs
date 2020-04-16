using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : AICharacter
{

    void Start()
    {
        this.maxHealth = 50f;
        this.movementSpeed = 8f;
        this.friendly = true;
         this.fovAngle = 90f;
        this.viewDistance = 20f;
        float interactRange = 1.5f;
        //this.gameObject.CompareTag = "Scientist";
    }

    void Update()
    {
        //Detect if player presses 'e' on them and follow if true        
        FollowOnKeyPress();
    }

    void FollowOnKeyPress()
    {
        // (3) If the player is looking at the AI and in radius, display option to follow
        // (4) If player presses "e" follow player
        // (5) Must do the same to see if the player wants to unfollow

        //If the player is in range and they press "e"
        if (this.playerInteractable && friendly == true && Input.GetKey(KeyCode.E))
        {
            //For this function I could use Vector3.MoveTowards (but this does not deal with obstacles)
            if (this.following == false)
            {
                //Pathfind to the player
                //this.pathfinding.startPos = this.gameObject.transform;
                //this.pathfinding.endPos = player.transform;
                this.following = true;
            }
            else if (this.following == true)
            {
                //Stop following the player
                //this.pathfinding.startPos = null;
                //this.pathfinding.endPos = null;
                this.following = false;
            }
        }
    }

}
