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
    /// The type of ammo acceptable by the weapon
    /// </summary>
    protected Ammo AmmoType;
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

    public void Weapons(string name, Vector3 position, bool useableByPlayer)
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

        //Physics.Raycast(Vector3 origin, Vector direction, out collisionInfo, float distance)
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxDistance))
        {
            //Print the name of the object that has been hit
            Debug.Log(hit.transform.name);
            //The target component of the object that has been hit (if the object has no target component then it is ignored?) is set equal to the target
            Target target = hit.transform.GetComponent<Target>();
            //If the gameObject hit has a target component (exists) then apply damage
            if (target != null)
            {
                //Apply the damage to the target in question
                target.TakeDamage(damage);
            }
            
        }

        //Play weapon animation
        //Decrement ammo in current magazine by one
        currentAmmoInMagazine -= 1;
        weaponIfFiring = false; //should be the last line of the subroutine
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
        if ((currentAmmoInMagazine+=reserveAmmo) != currentAmmoInMagazine)
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
       // yield return new WaitForSeconds(reloadTime);

    }

}
