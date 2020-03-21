using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewNode
{
    /// <summary>
    /// Distance from leading node to goal node
    /// </summary>
    float hCost;
    /// <summary>
    /// Distance from start node to leading node 
    /// </summary>
    float gCost;
    /// <summary>
    /// Total distance, hCost + gCost
    /// </summary>
    public float fCost;
    public bool isToutchingWall = false;
    public bool traversable = false;
    public bool isStairFloorNode = false;
    public bool isToutchingFloor = false;
    float radius = 0.5f;
    NewNode OppositeStairFloorNode;
    Player player;
    GameObject targetObj;
    GameObject originObj;
    //Layer 9 = Wall
    //Layer 12 = Floor
    //Layer 13 = Stair
    GameObject targetFloor;
    GameObject floor;
    public Vector3 pos;

    public NewNode(GameObject obj)
    {
        //Round down the x position to the nearest int
        int roundDownXPos = Convert.ToInt32(Math.Floor(obj.transform.position.x));
        //Round down the y position to the nearest int
        int roundDownZPos = Convert.ToInt32(Math.Floor(obj.transform.position.z));

        pos = new Vector3(roundDownXPos, obj.transform.position.z/*floor.transform.position.y*/, roundDownZPos);

        // FindFloor();

        //check if toutching wall
        if (Physics.CheckSphere(obj.transform.position, 0.5f, 9))
        {
            this.isToutchingWall = true;
            traversable = false;
        }

        //check if toutching floor
        if (Physics.CheckSphere(obj.transform.position, 0.5f, 12))
        {
            isToutchingFloor = true;
        }

        //check if toutching stair and floor layers
        if (Physics.CheckSphere(obj.transform.position, 0.5f, 13) && Physics.CheckSphere(obj.transform.position, 0.5f, 12))
        {
            isStairFloorNode = true;
        }
        
    }
    
    public NewNode returnThisNode()
    {
        return this;
    }

    public NewNode() // Is meant to exist to allow as a pointer
    {

    }

    public void CalculateCosts(Vector3 startPos, Vector3 endPos, Vector3 leadingPos)
    {
        GetHCost(leadingPos, endPos);
        GetGCost(startPos, leadingPos);
        GetFCost();
    }

    void GetFCost()
    {
        fCost = gCost + hCost;
    }

    void GetHCost(Vector3 leadingPos, Vector3 endPos)
    {
        hCost = Vector3.Distance(leadingPos, endPos);
    }

    void GetGCost(Vector3 startPos, Vector3 leadingPos)
    {
        gCost = Vector3.Distance(startPos, leadingPos);
    }

    //void FindFloor()
    //{
    //    RaycastHit hit;
    //    //Make a raycast down to find the floor of the target floor;
    //    Physics.Raycast(Node.pos, pos.down);
    //}

    //void findOppositeStairFloorNode()
    //{
    //    RaycastHit hit;
    //    //Make a raycast down to find the floor of the target floor;
    //    Physics.Raycast(target.transform.position, );
    //}


}
