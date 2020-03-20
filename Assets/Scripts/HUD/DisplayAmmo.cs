using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAmmo : MonoBehaviour
{
    public Text itemToDisplay;
    public Player player;
    public Inventory inventory;


    // Update is called once per frame
    void Update()
    {
        //DisplayAmountOfAmmo();
        //weapon = player.currentWeapon;
    }


    void DisplayAmountOfAmmo()
    {
        //itemToDisplay.text = $"{inventory.player.currentWeapon.currentAmmoInMagazine}/{inventory.player.currentWeapon.reserveAmmo}";
        //itemToDisplay.text = "Hello".ToString();//player.str.ToString();
        //itemToDisplay.text = $"{player.currentWeapon.currentAmmoInMagazine.ToString()}/{player.currentWeapon.reserveAmmo.ToString()}";
        //itemToDisplay.text = $"{weapon.currentAmmoInMagazine.ToString()}/{weapon.reserveAmmo.ToString()}";
    }
}
