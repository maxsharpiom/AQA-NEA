using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //Create a game object called floor001 and set it equal to the one in the scene
        GameObject floor001 = GameObject.Find("Floor001");
        //Set the xWidth and zLength equal to that of the floor
        int xwidth = Convert.ToInt32(Math.Floor(floor001.transform.localScale.x));
        int zlength = Convert.ToInt32(Math.Floor(floor001.transform.localScale.z));
        //Instantite a new grid with the given lengths
        Grid grid = new Grid(xwidth, zlength);
    }

}
