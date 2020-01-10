using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float maxHealth = 100;
    float movementSpeed = 5f;
    public float currentHealth;
    public float currentSpeed;
    public Weapon currentWeapon;

    void Start()
    {
        //Create an inventory;
        Inventory PlayerInventory = new Inventory();

    }

}
