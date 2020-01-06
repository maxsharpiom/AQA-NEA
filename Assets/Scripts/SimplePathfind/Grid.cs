using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid : MonoBehaviour
{

    MyList<GridNode> AllNodesList = new MyList<GridNode>();
    GridNode[,] gridArray;
    /// <summary>
    /// Class constructor
    /// Create a grid with the same width and height as the ingame floor
    /// </summary>
    /// <param name="width"></param>    
    /// <param name="height"></param>
    public Grid(int width, int height)
    {
        //A 2D grid array array to represent the grid
        //GridNode[,] gridArray = new GridNode[width, height];
        this.gridArray = new GridNode[width + 1, height + 1];
        //Print to console the width and height of the grid
        Debug.Log($"Width: {width}, Height: {height}");

        //Creates nodes all over the floor
        for (int x = 0; x <= width; x++)
        {
            for (int z = 0; z <= height; z++)
            {
                //Create nodes over the area of the floor top
                GridNode Node = new GridNode(x - (width / 2), z - (height / 2));

                if (Physics.CheckSphere(Node.position, 1, Node.wallMask))
                {
                    Node.obstructed = false;
                }

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

        //Rounded Vector3 position of the pos
        //Vector3 roundedPos = new Vector3(Convert.ToInt32(Math.Floor(pos.x)), 0, Convert.ToInt32(Math.Floor(pos.z)));

        GridNode nodeToFind = new GridNode(roundDownXPos, roundDownZPos);

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                if (gridArray[x, z] == nodeToFind)
                {
                    return gridArray[x, z];
                }                
            }
        }

        return null;

    }
}


//        return gridArray[roundDownXPos, roundDownZPos];

//        //For each node in the list of
//        foreach (GridNode Node in MyList<GridNode> AllNodesList)
//        {
//            if (Node.position.x == roundDownXPos && Node.position.y == roundDownYPos)
//            {
//                return Node;
//            }
//        }
//    }

//}
