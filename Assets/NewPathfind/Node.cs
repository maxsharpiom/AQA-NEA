using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Node
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
    float fCost;
    bool isToutchingWall = false;
    bool traversable = true;
    bool isStairFloorNode = false;
    bool isToutchingFloor = false;
    float radius = 0.5f;
    Node OppositeStairFloorNode;
    Player player;
    GameObject target;
    //Layer 9 = Wall
    //Layer 12 = Floor
    //Layer 13 = Stair
    GameObject targetFloor;
    GameObject floor;
    Vector3 pos;

    public Node(Vector3 position)
    {
        //Round down the x position to the nearest int
        int roundDownXPos = Convert.ToInt32(Math.Floor(position.x));
        //Round down the y position to the nearest int
        int roundDownZPos = Convert.ToInt32(Math.Floor(position.z));
        
        pos = new Vector3(roundDownXPos, 0, roundDownZPos);

       // FindFloor();

        //check if toutching wall
        if (Physics.CheckSphere(position, 0.5f, 9))
        {
            this.isToutchingWall = true;
            traversable = false;
        }

        //check if toutching floor
        if (Physics.CheckSphere(position, 0.5f, 12))
        {
            isToutchingFloor = true;
        }

        //check if toutching stair and floor layers
        if (Physics.CheckSphere(position, 0.5f, 13) && Physics.CheckSphere(position, 0.5f, 12))
        {
            isStairFloorNode = true;
        }
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
