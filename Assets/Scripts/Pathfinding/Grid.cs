//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class Grid
//{
//    /// <summary>
//    /// The position for the start of the pathfind
//    /// </summary>
//    public Transform originPosition;
//    /// <summary>
//    /// The wall Layermask - This corresponds with a node that is obstructed
//    /// </summary>
//    public LayerMask wallMask;
//    /// <summary>
//    /// The 2D side of the grid
//    /// </summary>
//    public Vector2 realGridSize;
//    /// <summary>
//    /// The radius of one node
//    /// </summary>
//    public float radius;
//    /// <summary>
//    /// The distance between nodes will spawn from one another
//    /// </summary>
//    public float spawnDistance;
//    /// <summary>
//    /// A 2D array that represents the Nodes within the grid
//    /// </summary>
//    Node[,] gridNodes;
//    /// <summary>
//    /// A list to represent the shortest path
//    /// </summary>
//    public MyList<Node> pathToFollow;
//    /// <summary>
//    /// The diameter of 1 node which is equal to radius*2
//    /// </summary>
//    float Diameter { get { return radius * 2; } }
//    /// <summary>
//    /// The x position of the node within the grid 
//    /// </summary>
//    int gridXNodePosition;
//    /// <summary>
//    /// The y position of the node within the grid
//    /// </summary>
//    int gridYNodePosition;
//    /// <summary>
//    /// The position of the bottom left most part of the grid
//    /// </summary>
//    Vector3 bottomLeftPosition;
//    //The actual world size of the floor
//    public float xActualSizeOfFloor;
//    public float yActualSizeofFloor;

//    void MakeGrid(int xSizeofFloorAsNode, int ySizeofFloorAsNode)
//    {
//        //Instantate a grid and then define it's size
//        Grid[,] grid = new Grid[xSizeofFloorAsNode, ySizeofFloorAsNode];

//        bottomLeftPosition = xActualSizeOfFloor;

//        for (int y = 0; y < ySizeOfFloor; y++)
//        {
//            for (int x = 0; x < xSizeOfFloor; x++)
//            {
//                Node Node = new Node(false,);
//            }
//        }
//    }

//    void DrawGrid()
//    {

//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        //Find the size of the floor in terms of nodes
//        int xSizeOfFloorAsNode = Convert.ToInt32(Math.Floor(xActualSizeOfFloor / Diameter));
//        int ySizeOfFloorAsNode = Convert.ToInt32(Math.Floor(yActualSizeofFloor / Diameter));
//        MakeGrid(xSizeOfFloorAsNode, ySizeOfFloorAsNode);
//    }
    
//}
