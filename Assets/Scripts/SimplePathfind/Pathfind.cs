using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfind
{
    public Transform startPos;
    public Transform endPos;
    //A list to represent the final path
    MyList<GridNode> FinishedPath = new MyList<GridNode>();
    GridNode LeadingNode; //The node that has the lowest fCost

    void Update()
    {
        FindPath(startPos.position, endPos.position);        
    }

    void FindPath(Vector3 startPos, Vector3 endPos)
    {
        //Find the leading node
        //Sort all the nodes in the list to find the lowest fCost
        //Return the node that is neighboruing the current leading node that has the lost fCost.

        //Find the node that is equal to the 
        GridNode startNode = GridNode.FindNode(startPos);
        LeadingNode = startNode; //Could be prone to error seeing that it is called in the Update()
        GridNode endNode = GridNode.FindNode(endPos);
        //Add the starting node to the list
        MyList.Add(startNode);
        //Calculate costs for the node
        GridNode.hCost = FindCost("hCost", startPos, endPos);
        GridNode.gCost = FindCost("gCost", startPos, endPos);
        GridNode.fCost = GridNode.hCost + GridNode.gCost;
        //Only add the end node once reached
    }

    float FindCost(string choice, Vector3 startPos, Vector3 endPos)
    {
        float cost;
        switch (choice)
        {
            case "hCost":
                cost = Pythagoras(/*the leading node, goal*/);
                break;
            case "gCost":
                FindCost = Pythagoras();              
                break;
        }

        return cost;
    }

    float Pythagoras(Vector3 startPos, Vector3 endPos)
    {
        float distance;

        return distance;
    }

    void FindNeighbouringNodes()
    {
        //Find the four nodes 
    }
}
