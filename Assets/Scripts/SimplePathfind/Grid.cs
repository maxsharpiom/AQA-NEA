using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="width"></param>    
    /// <param name="height"></param>
    public Grid(int width, int height)
    {      
        int [,] gridArray = new int[width, height];
        Debug.Log($"Width: {width}, Height: {height}");
               
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                Node Node = new Node(x, z);
            }
        }
    }
}
