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
    protected float interactRange = 2.5f;

    public void Awake()
    {
        //Create an inventory;
        inventory = new Inventory();
        currentHealth = maxHealth;
        this.gameObject.AddComponent<AudioListener>();
        AudioListener.volume = 0.025f;
    }

    void Update()
    {
        CheckDead();
        Interacting();
        //IsInInteractingRange();
        GetSurroundingObjects();
    }

    void GetSurroundingObjects()
    {
        Collider[] objs;
        objs = Physics.OverlapSphere(this.gameObject.transform.position, interactRange);
        foreach (var item in objs)
        {            
            if (item.tag == "CanPickup")
            {
                //if (inventory.CheckIfItemIsAlReadyInInventory(item.GetComponent<Item>()))
                //{
                    PickupItem(item.gameObject.GetComponent<Item>());
                    //Debug.Log($"{item.name} > picking up > {item.tag}");
                //}
                //Debug.Log($"{item.name} in inventory({inventory.CheckIfItemIsAlReadyInInventory(item.GetComponent<Item>())})");
            }
        }
    }

    //void ChangeLayer(GameObject item, int layer)
    //{
    //    item.gameObject.layer = layer;
    //    foreach (GameObject child in item.transform)
    //    {
    //        ChangeLayer(child, layer);
    //    }
    //}

    void PickupItem(Item item)
    {
        item.transform.parent = GameObject.Find("Weapon").transform;
        item.transform.position = GameObject.Find("WeaponHolder").transform.position;
        item.transform.rotation = GameObject.Find("WeaponHolder").transform.rotation;
        item.gameObject.GetComponent<Weapon>().playerCamera = GameObject.Find("WeaponCamera").GetComponent<Camera>();
        //item.gameObject.AddComponent<AudioSource>();
        //item.gameObject.GetComponent<Weapon>().attackSource = item.gameObject.GetComponent<AudioSource>();
        item.tag = "Holding";
        // ChangeLayer(item.GetComponent<GameObject>(), 11);
        inventory.AddItem(item);       
        item.playerIsHolding = true;
        //item.GetComponent<Weapon>().fireTime = 99999;
        //if (item.gameObject.GetComponent<Weapon>())
        //{
        //    item.gameObject.GetComponent<Weapon>().playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //    Instantiate(item, this.transform, true).GetComponent<GameObject>().SetActive(true);
        //    Destroy(item.GetComponent<Collider>());
        //    //Destroy(item);
        //}

    }

    //optional perameters, so have a default text box size
    //Could be dynamic so the size of the text box depends on the size of the text entered
    //void OnGUI(string TextToDisplay)
    //{
    //    float yOffsetFromPlayerCameraForward = +50f;
    //    //(xpos, ypos, width, height) all as float values
    //    GUI.Label(new Rect(playerCamera.transform.forward.x, playerCamera.transform.forward.y + yOffsetFromPlayerCameraForward, 200, 200), TextToDisplay);
    //}

    //public void PickUp()
    //{
    //    Item itemToPickUp;
    //    itemToPickUp = ReturnObjectLookingAt().GetComponent<Item>();
    //   // Debug.Log($"Item to pick up = {ReturnObjectLookingAt()}");
    //    //If the player is interacting with an item (something) and it can be picked up
    //    if (itemToPickUp!=null && itemToPickUp.GetComponent<Item>()/*itemToPickUp.GetType().ToString()=="Item"*/)
    //    {
    //        //Display pickup icon && name of item

    //        //Pickup if pressing E
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            inventory.AddItem(itemToPickUp);
    //            inventory.EquipItem(currentItem, itemToPickUp);
    //            currentItem = itemToPickUp; //Now equip that item

    //        }
    //    }
    //}

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

    //public bool InteractingWithPickupObject()
    //{
    //    Physics.CheckSphere(this.gameObject.transform.position, interactRange);

    //}

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
