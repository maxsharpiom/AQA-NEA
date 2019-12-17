using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    /// <summary>
    /// Class constructor
    /// Create a grid with the same width and height as the ingame floor
    /// </summary>
    /// <param name="width"></param>    
    /// <param name="height"></param>
    public Grid(int width, int height)
    {    
        //A 2D grid array array to represent the grid
        int [,] gridArray = new int[width, height];
        //Print to console the width and height of the grid
        Debug.Log($"Width: {width}, Height: {height}");

        //Creates nodes all over the floor
        for (int x = 0; x <= width; x++)
        {
            for (int z = 0; z <= height; z++)
            {
                Node Node = new Node(x-(width/2), z-(height/2));
            }
        }
                
    }    
}
