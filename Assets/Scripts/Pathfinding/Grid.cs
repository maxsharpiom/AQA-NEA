using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : GameObject
{
    /// <summary>
    /// The position for the start of the pathfind
    /// </summary>
    public Transform originPosition;
    /// <summary>
    /// The wall Layermask - This corresponds with a node that is obstructed
    /// </summary>
    public LayerMask wallMask;
    /// <summary>
    /// The 2D side of the grid
    /// </summary>
    public Vector2 realGridSize;
    /// <summary>
    /// The radius of one node
    /// </summary>
    public float radius;
    /// <summary>
    /// The distance between nodes will spawn from one another
    /// </summary>
    public float spawnDistance;
    /// <summary>
    /// A 2D array that represents the Nodes within the grid
    /// </summary>
    Node[,] grid;
    /// <summary>
    /// A list to represent the shortest path
    /// </summary>
    public MyList<Node> pathToFollow;
    /// <summary>
    /// The diameter of 1 node which is equal to radius*2
    /// </summary>
    float Diameter { get { radius * 2; } }
    /// <summary>
    /// The x position of the node within the grid 
    /// </summary>
    int gridXNodePosition;
    /// <summary>
    /// The y position of the node within the grid
    /// </summary>
    int gridYNodePosition;
    /// <summary>
    /// The position of the bottom left most part of the grid
    /// </summary>
    Vector3 bottomLeftPosition;
    //The actual world size of the floor
    public float xActualSizeOfFloor;
    public float yActualSizeofFloor;

    void MakeGrid()
    {
        //Instantate a grid and then define it's size
        Grid grid = new grid[xSizeofFloor, ySizeofFloor];
        bottomLeftPosition = xActualSizeOfFloor 

        for (int y = 0; y < ySizeOfFloor; y++)
        {
            for (int x = 0; x < xSizeOfFloor; x++)
            {
                Node Node = new Node(false,);
            }
        }
    }

    void DrawGrid()
    {

    }
    
    collider FloorCollider;
    Vector3 FloorSize;

    //float xSizeOfFloor = 50;
    //float ySizeOfFloor = 50;
    //The dimentions of the floor associated with that level
    float[,] GridSize = new float[xSizeOfFloor, ySizeOfFloor]; //50,50 is a placeholder for the current size of the level

    // Start is called before the first frame update
    void Start()
    {
        //Find the size of the floor in terms of nodes
        int xSizeOfFloorAsNode = Convert.ToInt32(Math.Floor(xActualSizeOfFloor / Diameter));
        int ySizeOfFloorAsNode = Convert.ToInt32(Math.Floor(yActualSizeofFloor / Diameter));        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Place the nodes for the pathfinding on the grid
    void PlaceNodesOnGrid(Vector3 FloorSize)
    {

        //Declare the position of the node, each 'FloorSize' tile at a time
        for (int y = FloorSize.y.bounds.min; y < FloorSize.y; i++)
        {
            for (int x = FloorSize.x.bounds.min; x < FloorSize.x; i++)
            {
                //Instantiates a GridNode at the specified position, with 0 rotation
                Instantiate(GridNode, Vector3(x, y, 0), Quaternion.Identity);
            }
        }

    }

}
