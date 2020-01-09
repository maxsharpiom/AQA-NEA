using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float maxHealth = 100;
    private float movementSpeed = 5f;
    Weapon weapon;
    public float fovAngle;
    GameObject Player = new GameObject.FindWithTag("Player");
    public float viewDistance;
    bool playerInSight;

    void Update()
    {
        ScanFOV();        
    }

    //The idle state of the enemy (before it interacts with the player)
    public Idle()
    {

    }

    void ScanFOV()
    {
        fovAngle = Vector3.Angle
    }

}
