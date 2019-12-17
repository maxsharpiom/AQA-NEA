using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfind
{
    public Transform startPos;
    public Transform endPos;
    //A list to represent the final path
    MyList<Node> FinishedPath = new MyList<Node>();
    Node LeadingNode; //The node that has the lowest fCost

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
        Node startNode = Node.FindNode(startPos);
        LeadingNode = startNode; //Could be prone to error seeing that it is called in the Update()
        Node endNode = Node.FindNode(endPos);
        //Add the starting node to the list
        MyList.Add(startNode);
        //Calculate costs for the node
        Node.hCost = FindCost("hCost", startPos, endPos);
        Node.gCost = FindCost("gCost", startPos, endPos);
        Node.fCost = Node.hCost + Node.gCost;
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
