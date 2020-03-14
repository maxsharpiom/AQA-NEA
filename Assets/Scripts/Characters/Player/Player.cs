using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;  
    public float maxArmour = 100f;
    public float currentArmour;
    public Camera playerCamera;
    public Item currentItem;
    public Inventory inventory;
    protected float interactRange = 5f;

    public void Awake()
    {
        //Create an inventory;
        inventory = new Inventory();
        currentHealth = maxHealth;    
    }

    void Update()
    {
        CheckDead();
        Interacting();
    }



    //optional perameters, so have a default text box size
    //Could be dynamic so the size of the text box depends on the size of the text entered
    //void OnGUI(string TextToDisplay)
    //{
    //    float yOffsetFromPlayerCameraForward = +50f;
    //    //(xpos, ypos, width, height) all as float values
    //    GUI.Label(new Rect(playerCamera.transform.forward.x, playerCamera.transform.forward.y + yOffsetFromPlayerCameraForward, 200, 200), TextToDisplay);
    //}

    public void PickUp()
    {
        Item itemToPickUp;
        itemToPickUp = ReturnObjectLookingAt().GetComponent<Item>();

        //If the player is interacting with an item (something) and it can be picked up
        if (itemToPickUp!=null && itemToPickUp.GetComponent<Item>()/*itemToPickUp.GetType().ToString()=="Item"*/)
        {
            //Display pickup icon && name of item

            //Pickup if pressing E
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory.AddItem(itemToPickUp);
                inventory.EquipItem(currentItem, itemToPickUp);
                currentItem = itemToPickUp; //Now equip that item
                
            }
        }
    }

    public GameObject ReturnObjectLookingAt()
    {
        GameObject targetLookingAt = null;
        RaycastHit hit;

        if ((Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRange)))
        {
            targetLookingAt = hit.collider.gameObject;
        }

        return targetLookingAt;
    }

    public bool Interacting(GameObject targetObject)
    {
        bool interacting = false;
        RaycastHit hit;
        if ((Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRange)))
        {
            interacting = true;
        }

        return interacting;
    }

    public bool Interacting()
    {        
        bool interacting = false;
        RaycastHit hit;
        if ((Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactRange)))
        {
            interacting = true;
            Debug.Log($"Interacting {interacting} : {hit.collider.gameObject.name}");
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
