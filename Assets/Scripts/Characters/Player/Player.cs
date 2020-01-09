using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject Player = new GameObject.FindWithTag("Player");
    float maxHealth = 100;
    float movementSpeed = 5f;
    public float currentHealth;
    public float currentSpeed;

    void Start()
    {
        //Create an inventory;
        Inventory PlayerInventory = new Inventory();
    }

}
