using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Node<T>
{
    //The data held within the node
    public T Data;
    //The Next Node infront of this node
    public Node<T> NextNode;
    //The Previous Node behind this node
    public Node<T> PreviousNode;

    /// <summary>
    /// Constructor to set a node's data equal to the input
    /// </summary>
    /// <param name="input"></param>
    public Node(T input)
    {
        //Node's data equal to input
        this.Data = input;
    }

}
