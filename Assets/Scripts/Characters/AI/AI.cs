using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    void Start()
    {
        this.gameObject.AddComponent(AIMovement); //may not be allowed to refrence it as this.
    public float maxHealth;
    public float movementSpeed;
    public Weapon weapon;
    public float fovAngle;
    public GameObject player = GameObject.Find("Player");
    public float viewDistance;
    public bool playerInSight;
    Rigidbody rigidbody = this.gameObject.AddComponent<RigidBody>();
    bool friendly;
    LayerMask playerGroundMask = LayerMask.GetMask("Player");
    public bool playerInteractable; // Set in the update
    //Add the pathfind script
    Pathfind pathfinding = this.gameObject.AddComponent<Pathfind>();
    bool following;
    float interactRange = 1.5f;
}
}
void Update()
{
    //ScanFOV();  
    playerLooking = PlayerLookingAtAI(playerInteractable, interactRange);

}

public bool PlayerLookingAtAI(bool playerInteractable, float interactRange)
{
    // (1) Create check sphere to tell if the player is within the radius of the AI
    // (2) If the player is within the radius of the AI, check if the player is looking at the AI
    RaycastHit lookRay;
    //If the player is in range and looking at the Scientit
    if (Physics.CheckSpere(transform.position, interactRange, playerGroundMask) && Physics.Raycast(player.transform.position, player.tranform.forward, out lookRay, interactRange) && lookRay.collider.gameObject.CompareTag("Scientist"))
    {
        playerLooking = true;
    }
    else
    {
        playerLooking = false;
    }
    return playerLooking;
}






