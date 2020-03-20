using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewGrid : MonoBehaviour
{
    bool arrived = false;
    MyList<NewNode> nodeList = new MyList<NewNode>();
    GameObject originObj;
    GameObject targetObj;
    NewNode leadingNode;
    NewNode startNode;
    NewNode endNode;
    GameObject originFloor;
    GameObject targetFloor;
    bool differentFloors = false;
    NewNode leftNode;
    NewNode rightNode;
    NewNode upNode;
    NewNode downNode;
    NewNode[] SourroundingNodes = new NewNode[4];
    GameObject originStairNode;
    GameObject targetStairNode;
    bool possibleToFind = true;
    ///If we want to find nodes on two floors, the origin 
    ///and target nodes may be overwritted with the first 
    ///floors node and the seconds floor nodes may not exist
    public NewGrid(int xSize, int ySize)
    {

    }

    void Pathfind(GameObject originObj, GameObject targetObj)
    {
        
        
        CreateStartNode();
        CreateEndNode();
        leadingNode = startNode;
        while (!arrived || possibleToFind)
        {
            CreateNeighbourNodes();
            FindNodeValuesAndStoreInArray();
            FindLeadingNode();
        }
    }
    
    void MoveToTopOfStairs()
    {
        originObj.transform.position = Vector3.MoveTowards(originStairNode.transform.position, targetStairNode.transform.position, originObj.GetComponent<GameObject>().GetComponent<AICharacter>().movementSpeed * Time.deltaTime);
    }

    void FindPathfindWithFloors()
    {
        GetFloors();
        CompareFloors(); // Done to see if a traversal of stairs is needed
        FindStairNodes();
        Pathfind(originObj, originStairNode);
    }

    void FindStairNodes()
    {
        Collider[] colliders;
        //overlap sphere with a stair node and see if it matches the floor of player or target                
        colliders = Physics.OverlapSphere(originStairNode.transform.position, 1f, 12);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject == originFloor)
            {
                originStairNode = colliders[i].gameObject;
            } 
        }
        colliders = Physics.OverlapSphere(targetStairNode.transform.position, 1f, 12);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject == targetFloor)
            {
                targetStairNode = colliders[i].gameObject;
            }
        }

        if (differentFloors && originStairNode != null && targetFloor != null)
        {
            possibleToFind = true;
        }

    }
    
    void CompareFloors()
    {
        if (originFloor == targetFloor)
        {
            differentFloors = false;
        }
        else
        {
            differentFloors = true;
        }
    }

    NewNode FindLeadingNode()
    {
        NewNode temp;
        //Hashtable ht = new Hashtable();
        //for (int i = 0; i < 4; i++)
        //{
        //    ht.Add(SourroundingNodes[i].fCost, SourroundingNodes[i]);
        //}
        //leadingNode = ht.get

        //Preforming basic bubble sort to find node with lowest fCost
        for (int o =0; o < SourroundingNodes.Length-2; o++)
        {
            for (int t = 0; t < SourroundingNodes.Length - 2; t++)
            {
                if (SourroundingNodes[o].fCost > SourroundingNodes[o+1].fCost)
                {
                    temp = SourroundingNodes[o + 1];
                    SourroundingNodes[o+1] = SourroundingNodes[o];
                    SourroundingNodes[o] = temp;
                }
            }
        }

        return SourroundingNodes[0];
    }

   
    void FindNodeValuesAndStoreInArray()
    {
        if (upNode.traversable)
        {
            upNode.CalculateCosts(startNode.pos, endNode.pos, leadingNode.pos);
            SourroundingNodes[0] = upNode;
        }

        if (downNode.traversable)
        {
            downNode.CalculateCosts(startNode.pos, endNode.pos, leadingNode.pos);
            SourroundingNodes[1] = downNode;
        }

        if (leftNode.traversable)
        {
            leftNode.CalculateCosts(startNode.pos, endNode.pos, leadingNode.pos);
            SourroundingNodes[2] = leftNode;
        }

        if (rightNode.traversable)
        {

            rightNode.CalculateCosts(startNode.pos, endNode.pos, leadingNode.pos);
            SourroundingNodes[3] = rightNode;
        }
    }

    void canTraverse()
    {
        if (upNode.isToutchingFloor && NotNullUnder(upNode.pos))
        {
            upNode.traversable = true;
        }
        if (downNode.isToutchingFloor && NotNullUnder(downNode.pos))
        {
            downNode.traversable = true;
        }
        if(leftNode.isToutchingFloor && NotNullUnder(leftNode.pos))
        {
            leftNode.traversable = true;
        }
        if (rightNode.isToutchingFloor && NotNullUnder(rightNode.pos))
        {
            rightNode.traversable = true;
        }

    }

    bool NotNullUnder(Vector3 pos)
    {
        RaycastHit hit;
        Physics.Raycast(pos, Vector3.down, out hit, Mathf.Infinity);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

    void CreateStartNode()
    {
        startNode = new NewNode(originObj.transform.position);
    }

    void CreateEndNode()
    {
        endNode = new NewNode(targetObj.transform.position);
    }

    //NewNode GetNodeUnder(Vector3 vector3) //shouldn't exist
    //{
    //    NewNode NodeHit;
    //    RaycastHit hit;
    //    Physics.Raycast(vector3, Vector3.down, out hit, Convert.ToInt32(Mathf.Infinity));
    //    NodeHit = hit.collider.gameObject.ge

    //}


    void GetFloors()
    {
        RaycastHit hit;
        Physics.Raycast(originObj.transform.position, Vector3.down, out hit, Convert.ToInt32(Mathf.Infinity));
        if (hit.collider.gameObject.tag == "Floor")
        {
            originFloor = hit.collider.gameObject;
        }
        Physics.Raycast(targetObj.transform.position, Vector3.down, out hit, Convert.ToInt32(Mathf.Infinity));
        if (hit.collider.gameObject.tag == "Floor")
        {
            targetFloor = hit.collider.gameObject;
        }
    }

    void CreateNeighbourNodes()
    {
        Vector3 position = new Vector3(leadingNode.pos.x - 1, leadingNode.pos.y, leadingNode.pos.z);
        leftNode = new NewNode(position);
        position = new Vector3(leadingNode.pos.x + 1, leadingNode.pos.y, leadingNode.pos.z);
        rightNode = new NewNode(position);
        position = new Vector3(leadingNode.pos.x, leadingNode.pos.y, leadingNode.pos.z+1);
        upNode = new NewNode(position);
        position = new Vector3(leadingNode.pos.x, leadingNode.pos.y, leadingNode.pos.z-1);
        downNode = new NewNode(position);
    }

    bool CheckArrived()
    {
        if (leadingNode.pos == endNode.pos)
        {
            arrived = true;
        }

        return arrived;
    }

}
