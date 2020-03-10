using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : MonoBehaviour
{
    protected float maxHealth;
    protected float maxArmour;
    protected float currentHealth;
    protected float currentArmour;
    public float movementSpeed;
    protected Weapon weapon;
    protected float angleBetweenForwardAndTarget; //Needs to be Vector3.Angle
    protected float viewAngle;
    protected float viewDistance;
    protected bool playerInSight;
    protected bool friendly;
    protected bool playerInteractable;
    protected bool following;
    protected float interactRange = 1.5f;    
    public bool playerLooking;
    LayerMask playerGroundMask;
    //protected Pathfind pathfinding = new Pathfind();
    //Add the AI movement script to the AI character class
    //AICharacter myScript = gameObject.AddComponent<AIMovement>();
    protected Vector3 fovFromPosition;
    protected float fovAngle;
    //Should probably be adapted not just for player but any two gameobjects
    protected GameObject player;
    protected bool dead;

    //public virtual void Start()
    //{

    //}

    void Awake()
    {
        Rigidbody AIRigidbody = gameObject.AddComponent<Rigidbody>();
        playerGroundMask = LayerMask.GetMask("Player");
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //FOV();  
        playerLooking = PlayerLookingAtAI(playerInteractable, interactRange);
        CheckIfDead();
    }

    protected void TakeDamage(float damage)
    {
        float remainingDamageToApply = damage;
        if (currentArmour > 0)
        {
            currentArmour -= damage;
            if (currentArmour < 0)
            {
                remainingDamageToApply = currentArmour * -1;
            }
        }

        if (currentHealth > 0)
        {
            currentHealth -= remainingDamageToApply;
        }

        if (currentHealth <= 0)
        {
            dead = true;
        }

    }

    void CheckIfDead()
    {
        if (dead)
        {
            //Play death anim and or sound
            //Destroy this gameObject
            object.Destroy(this.gameObject);
        }
    }

    void FOV()
    {
        //If the enemy is the first game item to be hit by the casted ray and is within a certain distance then it must be in sight
        //Cast the raycast forward, but translate the raycast by half of the fov angle to get an even amount each side
        //or
        //Create a gameObject in the shape of the FOV and if the player collides with it then it is seen

        //The direction of the enemy
        Vector3 enemyDirection = player.transform.position - this.transform.position;
        //Creating the line of sight ray and it's properties
        Ray lineOfSight = new Ray();
        lineOfSight.direction = enemyDirection;
        lineOfSight.origin = fovFromPosition;

        angleBetweenForwardAndTarget = Vector3.Angle(this.gameObject.transform.position, enemyDirection);
        RaycastHit closestObject;

        //player is within fov angle
        if (angleBetweenForwardAndTarget < viewAngle / 2 || angleBetweenForwardAndTarget > ((viewAngle * -1) / 2))
        {
            //Raycast made in direciton of player and info stored in hitInfo
            RaycastHit[] hitInfo = Physics.RaycastAll(lineOfSight, viewDistance);
            closestObject = ObjectWithLeastDistance(hitInfo);
            //Find the world object that has collided with the smaller distance. If the world object with the smalled distance = player
            for (int i = 0; i < hitInfo.Length; i++)
            {
                RaycastHit ray = hitInfo[i];
                if (ray.collider.gameObject == player)
                {
                    playerInSight = true;
                }
            }
        }

        //EG angleBetweenForwardAndTarget = 90
        //float fovStartAngle = ((angleBetweenForwardAndTarget * -1) / 2);//-45
        //float fovFinishAngle = (angleBetweenForwardAndTarget / 2);//45

        //for (int i = fovFinishAngle; i < fovStartAngle; i++)
        //{
        //    Physics.Raycast(fovFromPosition, transform.position.forward + fovStartAngle, out lineOfSight[i], viewDistance);
        //}

    }

    RaycastHit ObjectWithLeastDistance(RaycastHit[] hitInfo)
    {
        RaycastHit closestObject = new RaycastHit();
        float distanceBetweenRayCollisionAndEnemy;
        //Raycas
        //out of the array of gameobjects find the closest one
        for (int i = 0; i < hitInfo.Length; i++)
        {
            //Return an array giving the RaycastHit that has the least distance to the player
            distanceBetweenRayCollisionAndEnemy = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
            if (hitInfo[i].distance < hitInfo[i + 1].distance)
            {
                closestObject = hitInfo[i];
            }
            else if (hitInfo[i + 1].distance < hitInfo[i].distance)
            {
                closestObject = hitInfo[i + 1];
            }
        }
        return closestObject;
    }

    //this.gameObject.AddComponent(AIMovement); //may not be allowed to refrence it as this

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

