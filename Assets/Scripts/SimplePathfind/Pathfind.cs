using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using System;

public class Pathfind : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;    
    //A list to represent the final path
    MyList<GridNode> FinishedPath = new MyList<GridNode>();
    GridNode LeadingNode; //The node that has the lowest fCost
    bool arrived = false;

    void Update()
    {
        FindPath(startPos.position, endPos.position);
        FinishedPath.DisplayList();
    }

    void FindPath(Vector3 startPos, Vector3 endPos)
    {
        //Find the leading node
        //Sort all the nodes in the list to find the lowest fCost
        //Return the node that is neighboruing the current leading node that has the lost fCost.

        GridNode[] NodeCompareArray = new GridNode[9];
        int counter = 0;
        GridNode startNode = new GridNode(startPos);
        LeadingNode = startNode; //Could be prone to error seeing that it is called in the Update()
        GridNode endNode = new GridNode(endPos);

        ////Find the node that is equal to the 
        //startNode = Grid.FindNode(startPos);        
        //GridNode endNode = GridNode.FindNode(endPos);

        //Add the starting node to the list
        FinishedPath.Add(startNode);

        while (arrived == false)
        {
            if (LeadingNode.hCost == 0)
            {
                arrived = true;
            }
            else
            {
                //Create all 9 nodes (including the central one) around the leading node
                for (int x = -1; x < 2; x++)
                {
                    for (int z = -1; z < 2; z++)
                    {
                        counter += 1;
                        GridNode NodeToCompare = new GridNode(LeadingNode.position);
                        int newXPos = Convert.ToInt32(LeadingNode.position.x) - x;
                        int newZPos = Convert.ToInt32(LeadingNode.position.z) - z;
                        NodeToCompare.position = new Vector3(newXPos,0,newZPos);
                        FindCosts(NodeToCompare, startPos, endPos);
                        NodeCompareArray[counter] = NodeToCompare;
                    }
                    //FindCosts(startPos, endPos);
                }

                LeadingNode = ReturnNodeWithLowestFCost(NodeCompareArray);                
            }
            
        }   

        ////Calculate costs for the node
        //GridNode.hCost = FindCost("hCost", startPos, endPos);
        //GridNode.gCost = FindCost("gCost", startPos, endPos);
        //GridNode.fCost = GridNode.hCost + GridNode.gCost;
        //Only add the end node once reached
    }

    public GridNode ReturnNodeWithLowestFCost(GridNode[] NodeCompareArray)
    {        
        for (int i = 0; i < NodeCompareArray.Length; i++)
        {
            if (NodeCompareArray[i].fCost < LeadingNode.fCost && NodeCompareArray[i].obstructed == false)
            {
                NodeCompareArray[i] = LeadingNode;
            }
              
        }

        FinishedPath.Add(LeadingNode);
        return LeadingNode;
    }

    void FindCosts(GridNode Node, Vector3 startPos, Vector3 endPos)
    {
        Node.hCost = FindCost("hCost", startPos, endPos);
        Debug.Log($"hCost: {Node.hCost}");
        Node.gCost = FindCost("gCost", startPos, endPos);
        Debug.Log($"gCost: {Node.gCost}");
        Node.fCost = FindCost("fCost", startPos, endPos);
        Debug.Log($"fCost: {Node.fCost}");
    }

    float FindCost(string choice, Vector3 startPos, Vector3 endPos)
    {
        float cost = 0;
        switch (choice)
        {
            //Cost of leading node to target
            case "hCost":
                cost = Pythagoras(LeadingNode.position, endPos/*the leading node, goal*/);
                break;
                //Cost of starting node to leading node
            case "gCost":
                cost = Pythagoras(startPos, LeadingNode.position/*the leading node, goal*/);
                break;
                //gcost + hcost
            case "fCost":
                cost = LeadingNode.hCost + LeadingNode.gCost;
                break;
        }

        return cost;
    }

    float Pythagoras(Vector3 startPos, Vector3 endPos)
    {
        float distance;

        //do pythag

        distance = Mathf.Sqrt(Mathf.Pow(endPos.x-startPos.x,2)+Mathf.Pow(endPos.z-startPos.z,2));

        return distance;
    }

    void FindNeighbouringNodes()
    {
        //Find the four nodes 
    }
}
