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

    void Update()
    {
        CheckDead();
    }

    void CheckDead()
    {
        if (currentHealth <= 0)
        {
            DeathScreen();
        }
    }

    void DeathScreen()
    {
        SceneManager.LoadScene("DeathScreen");//17/01/2020 - Doesn't exist
    }

}
