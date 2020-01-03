using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid
{

    MyList<GridNode> AllNodesList = new MyList<GridNode>();    
    /// <summary>
    /// Class constructor
    /// Create a grid with the same width and height as the ingame floor
    /// </summary>
    /// <param name="width"></param>    
    /// <param name="height"></param>
    public Grid(int width, int height)
    {
        //A 2D grid array array to represent the grid
        GridNode[,] gridArray = new GridNode[width, height];
        //Print to console the width and height of the grid
        Debug.Log($"Width: {width}, Height: {height}");        
        
        //Creates nodes all over the floor
        for (int x = 0; x <= width; x++)
        {
            for (int z = 0; z <= height; z++)
            {
                //Create nodes over the area of the floor top
                GridNode Node = new GridNode(x-(width/2), z-(height/2));
                //Add the node to the list of all the nodes in the world
                AllNodesList.Add(Node);
                gridArray[x, z] = Node;
            }
        }                
    }

    public GridNode FindNode(Vector3 pos)
    {        
        //Round down the x position to the nearest int
        int roundDownXPos = Convert.ToInt32(Math.Floor(pos.x));
        //Round down the y position to the nearest int
        int roundDownZPos = Convert.ToInt32(Math.Floor(pos.z));

        return gridArray[roundDownXPos, roundDownZPos];

        //For each node in the list of 
        foreach (GridNode Node in MyList<GridNode> AllNodesList)
        {
            if (Node.position.x == roundDownXPos && Node.position.y == roundDownYPos)
            {
                return Node;
            }
        }
    }
}
