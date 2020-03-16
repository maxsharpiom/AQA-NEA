using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : Item
{
    //Maximum attack distance
    protected float maxDistance;
    /// <summary>
    /// Damage per attack
    /// </summary>
    public float damage; //Must be public beacuse Lvl1 boss has to change the damage dealt per attack
    /// <summary>
    /// The maxiumum amount of ammo at any one time
    /// </summary>
    protected float magazineSize;
    /// <summary>
    /// The type of ammo acceptable by the weapon     MAY NOT NEED
    /// </summary>
    protected string AmmoType;
    /// <summary>
    /// The time taken for a reload
    /// </summary>
    protected float reloadTime;
    /// <summary>
    /// The current ammo in the weapon's magazine
    /// </summary>
    public float currentAmmoInMagazine;
    /// <summary>
    /// The amount of ammo in reserve
    /// </summary>
    public float reserveAmmo;
    /// <summary>
    /// Is the player currently holding the weapon?
    /// </summary>
    protected bool playerIsHolding;
    /// <summary>
    /// Is the weapon currently being reloaded?
    /// </summary>
    protected bool weaponIsReloading;
    /// <summary>
    /// Is the weapon currently firing?
    /// </summary>
    protected bool weaponIfFiring;
    /// <summary>
    /// Direction the weapon is being pointed in
    /// </summary>
    protected Vector3 directionWeaponIsPoitingIn;
    /// <summary>
    /// The player camera
    /// </summary>
    public Camera playerCamera;
    /// <summary>
    /// A layermask used to selectivly ignore colliders
    /// </summary>
    protected int layerMask;
    /// <summary>
    /// Attack animation for weapon
    /// </summary>
    protected Animation attackAnim;
    /// <summary>
    /// Reload animation for weapon
    /// </summary>
    protected Animation reloadAnim;
    /// <summary>
    /// Attack audio for weapon
    /// </summary>
   // protected AudioSource attackAudio;
    /// <summary>
    /// Reload audio for weapon
    /// </summary>
    //protected AudioSource reloadAudio;    
    /// <summary>
    /// The time taken per attack |
    /// Used as a pause between each time fire is called
    /// </summary>
    /// <returns></returns>
    protected float fireTime;
    protected float recoilAmount;
    //protected MouseLook mouseLook;    
    protected bool automatic;
    protected const float throwForceFloat = 10f; //For grenades and stuff //May not need
    protected float explosionRadius;
    protected float firetime;
    //public Weapon(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    //{
    //    this.name = name;
    //    this.position = position;
    //    this.useableByPlayer = useableByPlayer;
    //}

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        // mouseLook = player.GetComponent<MouseLook>();        
    }

    protected void Update()
    {       
        ////Keeps checking if the weapon is fired
        CheckFireWeapon();
        ////Keeps checking if the weapon is being reloaded
        //CheckReloadWeapon();
        // ApplyLayer();
    }


    //protected void ApplyLayer()
    //{
    //    Debug.Log($"{gameObject.name}:{this.gameObject.transform.root}");
    //    this.gameObject.layer = 0;        
    //    if (this.gameObject.transform.root == player.transform.root)
    //    {
    //        this.gameObject.layer = 11;
    //    }
    //    else if (this.gameObject.transform.root != player.transform.root)
    //    {
    //        this.gameObject.layer = 0;
    //        Debug.Log($"{gameObject.name} reached here");
    //    }

    //    Debug.Log($"{this.gameObject.name}'s layer = {gameObject.layer}");
    //}

    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 100))
        {
            Debug.Log(hit.transform.name);
        }
    }

    protected void SetEqualAmmoType()
    {
        switch (this.AmmoType)
        {
            case "762mmAmmo":
                this.reserveAmmo = inventory.total762mmAmmo;
                break;
            case "9mmAmmo":
                this.reserveAmmo = inventory.total9mmAmmo;
                break;
            case "556mmAmmo":
                this.reserveAmmo = inventory.total556mmAmmo;
                break;
            case "357mmAmmo":
                this.reserveAmmo = inventory.total357mmAmmo;
                break;
            case "762mmAmmoTokarev":
                this.reserveAmmo = inventory.total762mmAmmoTokarev;
                break;
        }
    }

    //protected void ApplyRecoil(float recoilAmount)
    //{
    //    //Make a refrence to player movement to transform the player camera down
    //    //Apply transformation to player camera
    //    mouseLook.mouseY += recoilAmount * fireTime; //May happen at the same time, therefore cancel eachother out        
    //    //May need a pause here
    //    mouseLook.mouseY -= recoilAmount * fireTime;
    //}

    protected void CheckFireWeapon()
    {
        //Gets the current status of Fire1, not just for a single frame
        if (Input.GetButton("Fire1"))
        {
            FireWeapon();
        }
        else if (Input.GetButton("Fire1"))
        {

        }
        //if (Input.GetKey(KeyCode.Mouse1) && playerIsHolding == true && currentAmmoInMagazine > 0)
        //{
        //    FireWeapon();
        //}
        //else if (Input.GetKey(KeyCode.Mouse1) && playerIsHolding == true && currentAmmoInMagazine <= 0)
        //{
        //    //Play clicking sound (no ammo in chamber)
        //}
    }

    /// <summary>
    /// /// Some of this script derives from Brakey's youtube video
    /// https://www.youtube.com/watch?v=THnivyG0Mvo
    /// </summary>
    protected void FireWeapon()
    {
        weaponIfFiring = true;
        RaycastHit hit;
        //Casts a raycast maxDistance length from the player camera, outputs the info into hit
        if (/* && this.name != "HEGrenade"*/true)
        {
            Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxDistance);

            //Print the name of the object that has been hit            
            ///
            /// potentially a problem as we can only apply damage to AICharacters...
            ///
            //Getting the reference for the gameObject hit
            //WeaponHit itemHit = hit.transform.GetComponent<WeaponHit>(); //Each object that can recieve damage script much be attatched // May want to 
            GameObject itemHit = hit.collider.gameObject; //Stores the gameObject hit and stores it as a gameObject

            if (itemHit != null && itemHit.gameObject.tag == "CanTakeDamage")
            {
                itemHit.SendMessage("TakeDamage", damage);
                Debug.Log($"{this.name} > {damage} > {hit.collider.gameObject.name}");
            }
            //The target component of the object that has been hit (if the object has no target component then it is ignored?) is set equal to the target
            //Target target = hit.transform.GetComponent<Target>();
            ////If the gameObject hit has a target component (exists) then apply damage
            //if (target != null)
            //{
            //    //Apply the damage to the target in question
            //    target.TakeDamage(damage);
            //}

        }
        else if (this.name == "HEGrenade") //Throw the grenade
        {
            //Implies rigidbody already exists on the object, and we are just getting it to reference
            Rigidbody rigidBody = this.gameObject.GetComponent<Rigidbody>();
            //Transform gameObject 
            rigidBody.AddForce(playerCamera.transform.forward, ForceMode.Impulse); //https://docs.unity3d.com/ScriptReference/ForceMode.html
            //start timer -- cook time
            StartCoroutine(Timer(fireTime));
            //Explode
            Explode();
        }

        //Play weapon animation
        //Decrement ammo in current magazine by one        
        DecrementAmmo();
        //ApplyRecoil(this.recoilAmount);
        StartCoroutine(Timer(fireTime));
        weaponIfFiring = false; //should be the last line of the subroutine
    }

    void DecrementAmmo()
    {
        currentAmmoInMagazine -= 1;
    }

    void Explode()
    {
        float dealDamageToSourounding;
        //Returns all colliders into an array that overlap the sphere
        Collider[] explosionHit = Physics.OverlapSphere(this.position, explosionRadius);
        float distanceToPlayerSquared;

        //Inverse square law
        for (int i = 0; i < explosionHit.Length; i++)
        {
            //Creating a rigidbody and setting it equal to the whatever the rigidbody component of whatever the explosion has hit
            Rigidbody rigidbody = explosionHit[i].GetComponent<Rigidbody>();
            //If there exists a rigid body on that object
            if (rigidbody != null)
            {
                //Current issue is that things on the other side of a wall for instance still take damage
                distanceToPlayerSquared = Vector3.Distance(rigidbody.position, this.transform.position);
                dealDamageToSourounding = damage * (1 / distanceToPlayerSquared);
                rigidbody.AddExplosionForce(dealDamageToSourounding, this.transform.position, explosionRadius);
                //Watch out becuase the dealDamageToSouroundings may have been done twice
                rigidbody.SendMessage("TakeDamage", dealDamageToSourounding);
            }

        }
        //play explosion anim
    }

    /// <summary>
    /// Used to pause for a given period of time (seconds)
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    IEnumerator Timer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    protected void CheckReloadWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerIsHolding == true)
        {
            ReloadWeapon();
        }
    }

    protected void ReloadWeapon()
    {
        weaponIsReloading = true;
        Debug.Log("Reloading weapon...");

        //Ammo needed for the weapon to resuply fully its currentAmmoInMagazine
        float AmmoNeeded = magazineSize - currentAmmoInMagazine;
        float ReplenishAmmo = reserveAmmo - AmmoNeeded;

        //Only play the anim if there is enough ammo to reload
        if ((currentAmmoInMagazine += reserveAmmo) != currentAmmoInMagazine)
        {
            //play reload anim
        }

        if (ReplenishAmmo == 0)
        {
            currentAmmoInMagazine += reserveAmmo;
            reserveAmmo = 0;
        }
        else if (ReplenishAmmo < 0)
        {
            currentAmmoInMagazine += reserveAmmo;
            reserveAmmo = 0;
        }
        else if (ReplenishAmmo > 0)
        {
            currentAmmoInMagazine += AmmoNeeded;
            reserveAmmo -= AmmoNeeded;
        }

        //Add a pause
        Timer(reloadTime);

    }

}
