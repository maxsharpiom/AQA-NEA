using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapons : Item
{
    /// <summary>
    /// Name of the weapon
    /// </summary>
    string name;
    //Maximum attack distance
    float maxDistance;
    /// <summary>
    /// Damage per attack
    /// </summary>
    float damage;
    /// <summary>
    /// The maxiumum amount of ammo at any one time
    /// </summary>
    float magazineSize;
    /// <summary>
    /// The type of ammo acceptable by the weapon
    /// </summary>
    Ammo AmmoType;
    /// <summary>
    /// The time taken for a reload
    /// </summary>
    float reloadTime;
    /// <summary>
    /// The current ammo in the weapon's magazine
    /// </summary>
    int currentAmmoInMagazine;
    /// <summary>
    /// The amount of ammo in reserve
    /// </summary>
    int reserveAmmo;
    /// <summary>
    /// Is the player currently holding the weapon?
    /// </summary>
    bool playerIsHolding;
    /// <summary>
    /// Is the weapon currently being reloaded?
    /// </summary>
    bool weaponIsReloading;
    /// <summary>
    /// Is the weapon currently firing?
    /// </summary>
    bool weaponIfFiring;
    /// <summary>
    /// Direction the weapon is being pointed in
    /// </summary>
    Vector3 directionWeaponIsPoitingIn;
    /// <summary>
    /// The player camera
    /// </summary>
    public Camera playerCamera;   
    /// <summary>
    /// A layermask used to selectivly ignore colliders
    /// </summary>
    int layerMask;
    /// <summary>
    /// Attack animation for weapon
    /// </summary>
    public Animation attackAnim;
    /// <summary>
    /// Reload animation for weapon
    /// </summary>
    public Animation reloadAnim;
    /// <summary>
    /// Attack audio for weapon
    /// </summary>
    public AudioSouce attackAudio;
    /// <summary>
    /// Reload audio for weapon
    /// </summary>
    public AudioSource reloadAudio;

    void Update()
    {
        //Keeps checking if the weapon is fired
        CheckFireWeapon();
        //Keeps checking if the weapon is being reloaded
        CheckReloadWeapon();
    }

    void CheckFireWeapon()
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
    void FireWeapon()
    {
        weaponIfFiring = true;
        RaycastHit hit;

        //Physics.Raycast(Vector3 origin, Vector direction, out collisionInfo, float distance)
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxDistance))
        {
            //Print the name of the object that has been hit
            Debug.Log(hit.tranform.name);
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

    void CheckReloadWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R) && playerIsHolding == true)
        {
            ReloadWeapon();
        }        
    }

    void ReloadWeapon()
    {
        weaponIsReloading = true;
        Debug.Log("Reloading weapon...");

        //Ammo needed for the weapon to resuply fully its currentAmmoInMagazine
        int AmmoNeeded = magazineSize - currentAmmoInMagazine;
        int ReplenishAmmo = reserveAmmo - AmmoNeeded;

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

        yield return new WaitForSeconds(reloadTime);

    }

}
