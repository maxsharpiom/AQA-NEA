using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The only real use for this script is to apply gravity.
/// Movement through pathfinding is achieved through the Pathfinding script
/// </summary>
public class AIMovement : MonoBehaviour
{
    //The speed at which the enemy can move;
    public float speed = 6f;

    //The gravity that will be applied to the enemy
    public float gravity = -40f;

    ////Refrence to the GroundCheck object
    public Transform groundCheck;

    //Radius of sphere for GroundCheck
    public float groundDistance = 0.4f;

    //Allows us to control what objects the groundCheck will check for
    public LayerMask groundMask = LayerMask.GetMask("Ground"); // need to check is Ground is a valid mask

    //A boolean to check if we are grounded
    public bool isGrounded;

    //The enemie's current velocity
    public Vector3 velocity;

    public bool friendly;

    // Update is called once per frame
    void Update()
    {
        //Creates a sphere, that if it collides with anything that is in our groundMask to true
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //If we are toutching the ground and our y velocity is stationary
        if (isGrounded && velocity.y < 0)
        {
            //Velocity = -2f
            velocity.y = -2f;
        }

        //Apply gravity to the character's velocity
        velocity.y += gravity * Time.deltaTime;

       // Vector3 changeInVelocity = new Vector3(velocity.x, velocity.y, velocity.z);

        //Apply the gravity to the gameObject
        this.gameObject.transform.position = new Vector3(0,this.gameObject.transform.position.y - velocity.y,0);
    }

    

}
