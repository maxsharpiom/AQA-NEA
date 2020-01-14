using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Probs should be attatched to the door hinge
public class Door : MonoBehaviour
{
    public GameObject player = GameObject.Find("Player");
    LayerMask playerLayerMask = LayerMask.GetMask("Player");
    public float maxOpenAngle = 90;
    public float closedAngle = 0;
    public float currentAngle; //Not set to anything
    public bool playerCanInteract;
    float interactRange = 1.5f;
    bool doorOpen = false;

    void Update()
    {
        Interaction();
        doorOpen = CheckDoorStatus();
        currentAngle = //find the current angle
    }

    public CheckDoorStatus()
    {
        if (currentAngle > maxOpenAngle)
        {
            doorOpen = true;
        }
        else if (currentAngle < maxOpenAngle)
        {
            doorOpen = false;
        }
    }

    public void Interaction()
    {
        if (playerCanInteractWith())
        {
            if (Input.GetKey(KeyCode.e) && doorOpen = false)
            {
                OpenDoor();
            }
            else if (Input.GetKey(KeyCode.e) && doorOpen = True)
            {
                CloseDoor();
            }
        }
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
        if (Physics.CheckSpere(transform.position, interactRange, playerGroundMask) && Physics.Raycast(player.transform.position, player.tranform.forward, out lookRay, interactRange) && lookRay.collider.gameObject.CompareTag("Door"))
        {
            playerCanInteract = true;

        }
        else
        {
            playerCanInteract = false;
        }
        return playerLooking;
    }

}
