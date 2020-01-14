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
        if (this.startPos != null && this.endPos != null)
        {
            FindPath(startPos.position, endPos.position);
            TraversePath(FinishedPath);
            //FinishedPath.DisplayList();
        }
    }

    void TraversePath(MyList<GridNode> FinishedPath)
    {
        int counter = 1;
        bool arrived = false;
        while (arrived == false)
        {            
            GridNode NodeToTraverse = FinishedPath.ReturnObject(counter);
            Vector3 nodeToTraversePosition = NodeToTraverse.position;
            //wanting to move it to a position but need to access the vector3 pos //////////////////////////////////////////////////////////////////////////////////////////////////////////
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, nodeToTraversePosition, this.gameObject.GetComponent<Enemy>().movementSpeed/*movespeed of gameObject*/);
            CheckIfGameObjectArrived(arrived, nodeToTraversePosition);
        }        
        
    }

    bool CheckIfGameObjectArrived(bool arrived, Vector3 nodeToTraversePosition)
    {
        if (this.gameObject.transform.position == nodeToTraversePosition)
        {
            arrived = true;
        }
        else
        {
            arrived = false;
        }
        return arrived;
    }

    void FindPath(Vector3 startPos, Vector3 endPos)
    {
        //Find the leading node
        //Sort all the nodes in the list to find the lowest fCost
        //Return the node that is neighboruing the current leading node that has the lost fCost.

        //int counter = 0;

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
            if (LeadingNode.position == endNode.position)
            {
                arrived = true;
                Debug.Log("Arrived");
            }
            else
            {
                //An array the size of the number of traversable nodes around the leading node
                GridNode[] NodeCompareArray = new GridNode[CountNeighbouringNodesThatAreTraversable(LeadingNode)];

                NodeCompareArray = ReturnTraversableGridNode(NodeCompareArray.Length);

                //Finds the cost of each node that is traversable
                for (int i = 0; i < NodeCompareArray.Length; i++)
                {
                    FindCosts(NodeCompareArray[i], startPos, endPos);
                }

                LeadingNode = ReturnNodeWithLowestFCost(NodeCompareArray);
                
                Debug.Log(LeadingNode.position);
                //Debug.Log("Test");
                ////Create all 9 nodes (including the central one) around the leading node
                //for (int x = -1; x < 2; x++)
                //{
                //    for (int z = -1; z < 2; z++)
                //    {
                //        GridNode NodeToCompare = new GridNode(LeadingNode.position);
                //        int newXPos = Convert.ToInt32(LeadingNode.position.x) - x;
                //        int newZPos = Convert.ToInt32(LeadingNode.position.z) - z;
                //        NodeToCompare.position = new Vector3(newXPos, 0, newZPos);
                //        //If the node is not next to a wall add it to the array
                //        if (NodeToCompare.obstructed == false)
                //        {
                //            FindCosts(NodeToCompare, startPos, endPos);
                //            NodeCompareArray[counter] = NodeToCompare; //May be an index problem
                //            counter += 1;
                //        }
                //    }
                //    //FindCosts(startPos, endPos);
                //}

            }

        }

        ////Calculate costs for the node
        //GridNode.hCost = FindCost("hCost", startPos, endPos);
        //GridNode.gCost = FindCost("gCost", startPos, endPos);
        //GridNode.fCost = GridNode.hCost + GridNode.gCost;
        //Only add the end node once reached
    }

    GridNode[] ReturnTraversableGridNode(int NodeCompareArrayLength)
    {
        GridNode[] TraversableArray = new GridNode[NodeCompareArrayLength];
        int counter = 0;
        for (int x = -1; x < 2; x++)
        {
            for (int z = -1; z < 2; z++)
            {
                int newXPos = Convert.ToInt32(LeadingNode.position.x) - x;
                int newZPos = Convert.ToInt32(LeadingNode.position.z) - z;
                GridNode checkNode = new GridNode(new Vector3(newXPos, 0, newZPos));
                if (!checkNode.obstructed)
                {
                    TraversableArray[counter] = checkNode;
                    counter += 1;
                }
            }
        }
        return TraversableArray;
    }

    int CountNeighbouringNodesThatAreTraversable(GridNode LeadingNode)
    {
        int numberOfTraversableNodes = 0;

        for (int x = -1; x < 2; x++)
        {
            for (int z = -1; z < 2; z++)
            {
                int newXPos = Convert.ToInt32(LeadingNode.position.x) - x;
                int newZPos = Convert.ToInt32(LeadingNode.position.z) - z;
                GridNode checkNode = new GridNode(new Vector3(newXPos, 0, newZPos));
                if (!checkNode.obstructed)
                {
                    numberOfTraversableNodes += 1;
                }
            }
        }

        return numberOfTraversableNodes;
    }

    public GridNode ReturnNodeWithLowestFCost(GridNode[] NodeCompareArray)
    {
        for (int i = 0; i < NodeCompareArray.Length; i++) //object refrece error, becuase you are trying to refrence an object that may not be in the array?
        {
            if (NodeCompareArray[i].fCost < LeadingNode.fCost)
            {
                LeadingNode = NodeCompareArray[i];
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

        distance = Mathf.Sqrt(Mathf.Pow(endPos.x - startPos.x, 2) + Mathf.Pow(endPos.z - startPos.z, 2));

        return distance;
    }

    void FindNeighbouringNodes()
    {
        //Find the four nodes 
    }
}
