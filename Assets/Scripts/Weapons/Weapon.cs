using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapons : Item
{
    string name;
    float maxDistance;
    float damage;
    float magazineSize;
    //Ammo type has not yet been made
    Ammo AmmoType;
    float reloadTime;
    int currentAmmoInMagazine;
    int reserveAmmo;
    bool playerIsHolding;
    bool weaponIsReloading;
    bool weaponIfFiring;
    Vector3 positionInWorld;
    Vector3 attackOriginPosition; //EG. the barrel of a gun
    Vector3 directionWeaponIsPoitingIn;
    public Camera playerCamera;
    bool canFire;
    int layerMask; //Layermask used to selectivly ignore colliders

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
    /// /// Some of this script derives from Brakey's youtube
    /// https://www.youtube.com/watch?v=THnivyG0Mvo
    /// </summary>
    void FireWeapon()
    {
        weaponIfFiring = true;
        RaycastHit hit;

        //Physics.Raycast(Vector3 origin, Vector direction, out collisionInfo, float distance)
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxDistance))
        {
            Debug.Log(hit.tranform.name);
            //The target component of the object that has been hit (if the object has no target component then it is ignored?) is set equal to the target
            Target target = hit.transform.GetComponent<Target>();
            //If the gameObject hit has a target component (exists) sthen apply damage
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
        if (Input.GetKeyDown(KeyCode.R) && playerIsHolding == true && currentAmmoInMagazine < magazineSize && reserveAmmo > 0)
        {
            ReloadWeapon();
        }        
    }

    void ReloadWeapon()
    {
        Debug.Log("Reloading weapon...");

        //Ammo needed for the weapon to resuply fully its currentAmmoInMagazine
        int AmmoNeeded = magazineSize - currentAmmoInMagazine;

        int ReplenishAmmo = reserveAmmo - AmmoNeeded;

        if (ReplenishAmmo == 0)
        {
            CurrentAmmo += ReserveAmmo;
            ReserveAmmo = 0;
        }
        else if (ReplenishAmmo < 0)
        {
            CurrentAmmo += ReserveAmmo;
            ReserveAmmo = 0;
        }
        else if (ReplenishAmmo > 0)
        {
            CurrentAmmo += AmmoNeeded;
            ReserveAmmo -= AmmoNeeded;
        }


    }

}
