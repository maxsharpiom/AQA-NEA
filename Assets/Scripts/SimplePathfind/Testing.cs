using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GameObject floor001 = GameObject.Find("Floor001");        
        int xwidth = Convert.ToInt32(Math.Floor(floor001.transform.localScale.x));
        int zlength = Convert.ToInt32(Math.Floor(floor001.transform.localScale.z));   
        Grid grid = new Grid(xwidth, zlength);
    }

}
