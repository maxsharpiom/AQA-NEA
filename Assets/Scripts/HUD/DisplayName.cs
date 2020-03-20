using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{
    public Text itemToDisplay;
    public Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        itemToDisplay = GameObject.Find("WeaponName").GetComponent<Text>();        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current weapon : " + player.inventory.currentItem.ToString());
        DisplayWeaponName();
    }

    void DisplayWeaponName()
    {
        //Debug.Break();
        itemToDisplay.text = player.inventory.currentItem.ToString();
        //itemToDisplay.text = $"{player.currentItem.transform.name.ToString()}";
    }
}
