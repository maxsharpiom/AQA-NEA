using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    collider NodeCollider;
    Vector3 NodeSize;

    //Heuristic estimated cost from vertex n to the goal (an estimate)
    float hCost;
    //Exact cost of the path from the starting point to any vertex n
    float gCost;
    //Total estimated cost of path through node n
    float fCost { get {hCost + gCost; } }
    //The x position of the node within the grid
    public int gridXNodePosition;
    //The y position of the node within the grid
    public int gridYNodePosition;
    //A boolean to show if the node is neighbouring something that not traversable
    public bool obstructed;
    //The position of the node in the game
    public Vector3 position;
    //The previous node - Used to traverse back through the shortest path
    public Node parentNode;

    /// <summary>
    /// The node constructor that sets all the values equal
    /// </summary>
    /// <param name="obstructed"></param>
    /// <param name="position"></param>
    /// <param name="gridXNodePosition"></param>
    /// <param name="gridYNodePosition"></param>
    Node(bool obstructed, Vector3 position, int gridXNodePosition, int gridYNodePosition)
    {
        obstructed = this.obstructed;
        position = this.position;
        gridXNodePosition = this.gridXNodePosition;
        gridYNodeposition = this.gridYNodePosition;

        //Also need to find out if the node is toutching another
    }
    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    //The diameter of the node which will be relative to the size of the floor
    float diameter;

    //The radius of the node
    float radius = diameter / 2;

    //NodeCollider = GetComponent<NodeCollider>();
    
    bool isWall = CheckIfToutchingWall;

    bool CheckIfToutchingWall()
    {

    }

    void GridNode(float[,] Location)
    {

        MoveGridNodeToInGamePosition();
    }


    void MoveGridNodeToInGamePosition()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
