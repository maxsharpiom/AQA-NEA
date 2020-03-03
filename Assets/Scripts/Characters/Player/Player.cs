﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const float maxHealth = 100;
    public float currentHealth;
    public Weapon currentWeapon;
    public const float maxArmour = 100f;
    public float currentArmour;
    public Camera playerCamera;
    public Inventory PlayerInventory;

    public void Awake()
    {
        //Create an inventory;
        PlayerInventory = new Inventory();
        currentHealth = maxHealth;
    }

    void Update()
    {
        CheckDead();
    }

    //optional perameters, so have a default text box size
    //Could be dynamic so the size of the text box depends on the size of the text entered
    void OnGUI(string TextToDisplay)
    {
        float yOffsetFromPlayerCameraForward = +50f;
        //(xpos, ypos, width, height) all as float values
        GUI.Label(new Rect(playerCamera.transform.forward.x, playerCamera.transform.forward.y + yOffsetFromPlayerCameraForward, 200, 200), TextToDisplay);
    }

    public bool Interacting(GameObject targetObject, float interactRangeOfTargetObject)
    {
        bool interacting = false;
        RaycastHit hit;
        if ((Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRangeOfTargetObject)))
        {
            interacting = true;
        }
        return interacting;
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
