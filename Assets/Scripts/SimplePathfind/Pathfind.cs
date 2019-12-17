using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfind : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;

    void Update()
    {
        FindPath(startPos.position, endPos.position);
    }

    void FindPath(Vector3 startPos, Vector3 endPos)
    {
        Node startNode = Node.FindNode(startPos);
        Node endNode;
    }    
}
