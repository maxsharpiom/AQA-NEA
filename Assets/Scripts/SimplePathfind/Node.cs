using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Node
{    
    bool obstructed;
    //Heuristic estimated cost from vertex n to the goal(an estimate)
    float hCost;
    //Exact cost of the path from the starting point to any vertex n
    float gCost;
    //Total estimated cost of path through node n
    float fCost;   
    //The position of the node in the game
    public Vector3 position;
    //The previous node - Used to traverse back through the shortest path
    public Node parentNode;
    public Vector3 topLeftPositon;

    GameObject floor001 = GameObject.Find("Floor001");
    
    public Node(float xPos, float zPos)
    {
        //Debug.Log($"{floor001.transform.position}");
        //position        
        //position = position - Vector3.right * xPos - Vector3.forward * zPos;
        
        Debug.Log($"{Vector3.right}");
        //position = position +
        //Debug.Log($"{position}");
    }

    Vector3 ReturnWorldPosition(float xPos, float yPos)
    {
        return new Vector3(xPos, yPos);
    }

}
