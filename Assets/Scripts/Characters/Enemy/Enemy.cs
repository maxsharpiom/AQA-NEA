using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float movementSpeed = 5f;
    public Weapon weapon;
    public float fovAngle;
    public GameObject player = GameObject.Find("Player");
    GameObject enemy = new GameObject("Enemy");
    public float viewDistance;
    public bool playerInSight;
    Rigidbody rigidbody = enemy.AddComponent<Rigidbody>();

    void Start()
    {
        
    }

    void Update()
    {
        //ScanFOV();        
    }

    //The idle state of the enemy (before it interacts with the player)
    //public Idle()
    //{

    //}

    //void ScanFOV()
    //{
    //    fovAngle = Vector3.Angle
    //}

}
