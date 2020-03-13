using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{    
    public Text itemToDisplay;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        DisplayWeaponName();
    }

    void DisplayWeaponName()
    {
        itemToDisplay.text = $"{player.currentItem.transform.name.ToString()}";
    }
}
