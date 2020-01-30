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
    public float maxArmour = 100f;
    public float currentArmour;    

    public void Start()
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

    void ApplyHealth(float amount)
    {
        this.currentHealth += amount;
        if (this.currentHealth > maxHealth)
        {
            this.currentHealth = maxHealth;
        }
    }

    void ApplyArmour(float amount)
    {
        this.currentArmour += amount;
        if (this.currentArmour > maxArmour)
        {
            this.currentArmour = maxArmour;
        }
    }

    void DeathScreen()
    {
        //SceneManager.LoadScene("DeathScreen");//17/01/2020 - Doesn't exist
    }

}
