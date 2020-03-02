using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Probs should be attatched to the door hinge
//Door needs to start closed
public class Door : MonoBehaviour
{
    public Player player;// = GameObject.Find("Player"); ## No link to a GameObject?
    public LayerMask playerLayerMask = LayerMask.GetMask("Player");
    public float maxOpenAngle = 90;
    public float closedAngle = 0;    
    public bool playerCanInteract;
    float interactRange = 1.5f;
    public bool doorOpen = false;
    public float currentAngle/* = transform.eulerAngles.y*/; //Not set to anything
    
    private void Start()
    {
        currentAngle = transform.eulerAngles.y;
    }

    void Update()
    {
        Interaction();
        doorOpen = CheckDoorStatus();
        //currentAngle = //find the current angle
    }

    public bool CheckDoorStatus()
    {
        if (currentAngle > maxOpenAngle)
        {
            doorOpen = true;
        }
        else if (currentAngle < maxOpenAngle)
        {
            doorOpen = false;
        }
        return doorOpen;
    }

    public void Interaction()
    {
        //Testing the interacting function in player
        if (player.Interacting(this.gameObject, interactRange))
        {
            if (Input.GetKey(KeyCode.E) && doorOpen == false)
            {
                OpenDoor();
            }
            else if (Input.GetKey(KeyCode.E) && doorOpen == true)
            {
                CloseDoor();
            }
        }
        //or
        //if (playerCanInteractWith())
        //{
        //    if (Input.GetKey(KeyCode.E) && doorOpen == false)
        //    {
        //        OpenDoor();
        //    }
        //    else if (Input.GetKey(KeyCode.E) && doorOpen == true)
        //    {
        //        CloseDoor();
        //    }
        //}
    }

    public void CloseDoor()
    {
        //Rotate the gameObject -90 in the y axis
        this.transform.eulerAngles = new Vector3(0,-maxOpenAngle,0) * Time.deltaTime;
    }

    public void OpenDoor()
    {
        //Rotate the gameObject 90 in the y axis
        this.transform.eulerAngles = new Vector3(0, maxOpenAngle, 0) * Time.deltaTime;
    }

    public bool playerCanInteractWith()
    {
        RaycastHit lookRay;
        //If the player is in range and looking at the Door      
        if (Physics.CheckSphere(transform.position, interactRange, playerLayerMask) && Physics.Raycast(player.transform.position, player.transform.forward, out lookRay, interactRange) && lookRay.collider.gameObject.CompareTag("Door"))
        {
            playerCanInteract = true;

        }
        else
        {
            playerCanInteract = false;
        }
        return playerCanInteract;
    }
       
}
