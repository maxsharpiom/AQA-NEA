using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
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
    public LayerMask groundMask;

    //A boolean to check if we are grounded
    bool isGrounded;

    //The player's current velocity
    Vector3 velocity;
    
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

        //Apply gravity to the player's velocity
        velocity.y += gravity * Time.deltaTime;
    }
}
