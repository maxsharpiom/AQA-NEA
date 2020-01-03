using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridNode
{
    bool obstructed = false;
    //Heuristic estimated cost from vertex n to the goal(an estimate)
    public float hCost;
    //Exact cost of the path from the starting point to any vertex n
    public float gCost;
    //Total estimated cost of path through node n
    public float fCost;   
    //The position of the node in the game
    public Vector3 position;
    //The previous node - Used to traverse back through the shortest path
    public GridNode parentNode;
    public Vector3 topLeftPositon;
    //A layer mask which will be obstructed by the pathfind
    public LayerMask wallMask;    
    GameObject floor001 = GameObject.Find("Floor001");

    public GridNode(float xPos, float zPos)
    {    
        //Set the position of the node
        position.Set(xPos,0,zPos);

        Debug.Log($"{position}");

        //Returns true if the node is toutching an object with the, "wallMask" LayerMask
        obstructed = Physics.CheckSphere(position,0.5f, wallMask);        
    }
    
    public GridNode FindNode(Vector3 pos)
    {
        //Round down the x position to the nearest int
        int roundDownXPos = Convert.ToInt32(Math.Floor(pos.x));
        //Round down the y position to the nearest int
        int roundDownYPos = Convert.ToInt32(Math.Floor(pos.y));

        //For each node in the list of 
        foreach (GridNode Node in Grid.AllNodesList)
        {
            if (Node.position.x == roundDownXPos && Node.position.y == roundDownYPos)
            {
                return Node;
            }            
        }
    }

}
