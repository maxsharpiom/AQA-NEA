using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T>
{
    //The data held within the node
    public T Data;
    //The Next GridNode infront of this node
    public Node<T> NextNode;
    //The Previous GridNode behind this node
    public Node<T> PreviousNode;

    /// <summary>
    /// Constructor to set a node's data equal to the input
    /// </summary>
    /// <param name="input"></param>
    public Node(T input)
    {
        //GridNode's data equal to input
        this.Data = input;
    }

}
