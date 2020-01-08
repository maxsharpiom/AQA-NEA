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
    float currentAmmoInMagazine;
    float reserveAmmo;
    bool playerIsHolding;
    bool weaponIsReloading;
    bool weaponIfFiring;
    Vector3 positionInWorld;
    Vector3 attackOriginPosition; //EG. the barrel of a gun
    Vector3 directionWeaponIsPoitingIn;
    bool canFire;

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

    void FireWeapon()
    {
        weaponIfFiring = true;
        //Fire raycast from origin forward facing the obeject
        Ray Ray = new Ray(Vector3 attackOriginPosition, Vector3 directionWeaponIsPoitingIn);
        if (Physics.Raycast(Ray, out Ray, float distance))
        {
            if (Ray.collider.tag == "enemy") //will change
            {
                //Apply damage to enemy in question
            }
        }
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

    }

}
