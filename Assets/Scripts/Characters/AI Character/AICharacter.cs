using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : MonoBehaviour
{
    protected float maxHealth;
    public float movementSpeed;
    //protected Weapon weapon;
    protected float fovAngle;
    protected GameObject player = GameObject.Find("Player");
    protected float viewDistance;
    protected bool playerInSight;
    protected bool friendly;
    protected bool playerInteractable;
    protected bool following;
    protected float interactRange = 1.5f;
    protected LayerMask playerGroundMask = LayerMask.GetMask("Player");
    public bool playerLooking;
    protected Pathfind pathfinding = new Pathfind();

    void Start()
    {

    }

    void Update()
    {
        //ScanFOV();  
        playerLooking = PlayerLookingAtAI(playerInteractable, interactRange);
    }

    //this.gameObject.AddComponent(AIMovement); //may not be allowed to refrence it as this

    //Rigidbody AIRigidbody = gameObject.AddComponent<RigidBody>();    


    //Add the pathfind script
    //Pathfind pathfinding = gameObject.AddComponent<Pathfind>();    

    public bool PlayerLookingAtAI(bool playerInteractable, float interactRange)
    {
        // (1) Create check sphere to tell if the player is within the radius of the AI
        // (2) If the player is within the radius of the AI, check if the player is looking at the AI
        RaycastHit lookRay;
        //If the player is in range and looking at the Scientit
        if (Physics.CheckSphere(transform.position, interactRange, playerGroundMask) && Physics.Raycast(player.transform.position, player.transform.forward, out lookRay, interactRange) && lookRay.collider.gameObject.CompareTag("Scientist"))
        {
            playerLooking = true;
        }
        else
        {
            playerLooking = false;
        }
        return playerLooking;
    }
}

