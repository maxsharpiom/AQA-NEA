using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : Item
{
    /// <summary>
    /// The position of the weapon
    /// </summary>
    Vector3 position;
    /// <summary>
    /// The name of the weapon
    /// </summary>
    protected string name;
    //Maximum attack distance
    protected float maxDistance;
    /// <summary>
    /// Damage per attack
    /// </summary>
    protected float damage;
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
    protected float currentAmmoInMagazine;
    /// <summary>
    /// The amount of ammo in reserve
    /// </summary>
    protected float reserveAmmo;
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
    protected Camera playerCamera;
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
    protected AudioSource attackAudio;
    /// <summary>
    /// Reload audio for weapon
    /// </summary>
    protected AudioSource reloadAudio;
    /// <summary>
    /// Is the weapon useable by the player?
    /// </summary>
    protected bool useableByPlayer;
    /// <summary>
    /// The time taken per attack |
    /// Used as a pause between each time fire is called
    /// </summary>
    /// <returns></returns>
    protected float fireTime;
    protected float recoilAmount;
    protected MouseLook mouseLook = this.player.GetComponent<MouseLook>();    
    protected bool automatic;
    protected const float throwForce = 10f; //For grenades and stuff
    protected float explosionRadius;    

    public Weapon(string name, Vector3 position, bool useableByPlayer) : base(name, position, useableByPlayer)
    {
        this.name = name;
        this.position = position;
        this.useableByPlayer = useableByPlayer;
    }

    protected void Update()
    {
        //Keeps checking if the weapon is fired
        CheckFireWeapon();
        //Keeps checking if the weapon is being reloaded
        CheckReloadWeapon();
    }

    protected void SetEqualAmmoType()
    {
        switch (this.AmmoType)
        {
            case "762mmAmmo":
                this.reserveAmmo = player.Inventory.total762mmAmmo;
                break;
            case "9mmAmmo":
                this.reserveAmmo = player.Inventory.total9mmAmmo;
                break;
            case "556mmAmmo":
                this.reserveAmmo = player.Inventory.total556mmAmmo;
                break;
            case "357mmAmmo":
                this.reserveAmmo = player.Inventory.total357mmAmmo;
                break;
            case "762mmAmmoTokarev":
                this.reserveAmmo = player.Inventory.total762mmAmmoTokarev;
                break;
        }
    }

    protected void ApplyRecoil(float recoilAmount)
    {
        //Make a refrence to player movement to transform the player camera down
        //Apply transformation to player camera
        mouseLook.mouseY += recoilAmount * fireTime;
        //mouseLook.mouseY -= recoilAmount * fireTime;
    }

    protected void CheckFireWeapon()
    {
        if (Input.GetKey(KeyCode.Mouse1) && playerIsHolding == true && currentAmmoInMagazine > 0)
        {
            FireWeapon();
        }
        else if (Input.GetKey(KeyCode.Mouse1) && playerIsHolding == true && currentAmmoInMagazine <= 0)
        {
            //Play clicking sound (no ammo in chamber)
        }
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
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxDistance))
        {
            //Print the name of the object that has been hit
            Debug.Log(hit.transform.name);
            ///
            /// potentially a problem as we can only apply damage to AICharacters...
            ///
            //Getting the reference for the gameObject hit
            WeaponHit itemHit = hit.transform.GetComponent<WeaponHit>();
            if (itemHit != null)
            {
                itemHit.TakeDamage(this.damage);
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

        if (this.name == "HEGrenade")
        {
            //Implies rigidbody already exists on the object, and we are just getting it to reference
            rigidBody = GetComponent<RigidBody>();
            //Transform gameObject
            rigidBody.AddForce(playerCamera.transform.forward, throwForce);
            //start timer -- cook time
            StartCoroutine(Timer(fireTime));
            //explode
            Explode();
        }

        //Play weapon animation
        //Decrement ammo in current magazine by one
        currentAmmoInMagazine -= 1;
        ApplyRecoil(this.recoilAmount);
        StartCoroutine(Timer(fireTime));
        weaponIfFiring = false; //should be the last line of the subroutine
    }

    void Explode()
    {
        float dealDamageToSourounding;
        //Returns true if there are any colliders overlapping the sphere
        Collider[] explosionHit = Physics.OverlapSphere(this.position, explosionRadius);
        float distanceToPlayerSquared;

        //Inverse square law
        for (int i = 0; i < explosionHit.Length; i++)
        {
            distanceToPlayerSquared = Vector3.distance(explosionHit.position, this.transform.position);
            dealDamageToSourounding = maximumDamage * (1 / distanceToPlayerSquared);
            explosionHit.SendMessage("TakeDamage", dealDamageToSourounding);
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
