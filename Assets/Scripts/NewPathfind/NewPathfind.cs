using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewPathfind : MonoBehaviour
{
    bool arrived = false;
    MyList<NewNode> nodeList = new MyList<NewNode>();
    GameObject originObj;
    GameObject targetObj;
    GameObject finaltargetObj;
    NewNode leadingNode;
    NewNode startNode;
    NewNode endNode; //used to reference going to stairs as well as the actual end node
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
    bool setUp = false;
    ///If we want to find nodes on two floors, the origin 
    ///and target nodes may be overwritted with the first 
    ///floors node and the seconds floor nodes may not exist
    //public NewPathfind(int xSize, int ySize)
    //{

    //}

    public NewPathfind(GameObject originObj, GameObject targetObj)
    {
        //Debug.Break();
        //Debug.Log("Break");
        //Debug.Log("originObj = " + originObj);
        //Debug.Log("targetObj = " + targetObj);
        while (!arrived && possibleToFind) //arrived is used for both to stairs and to the total goal
        {
            finaltargetObj = targetObj;
            if (setUp)
            {
                Pathfind(originObj, targetObj);
                nodeList.DisplayList();
            }
            else if (!setUp)
            {
                SetUpPathfind(originObj, targetObj);
            }
        }
    }

    void Pathfind(GameObject originObj, GameObject targetObj)
    {

        CreateNeighbourNodes();
        FindNodeValuesAndStoreInArray();
        FindLeadingNode();
        nodeList.Add(leadingNode);
        Gizmos.color = new Color(0, 1, 0, 1);
        Gizmos.DrawCube(leadingNode.pos, new Vector3(1, 1, 1));
        CheckArrived(leadingNode.pos, targetObj.transform.position);

    }

    void SetUpPathfind(GameObject originObj, GameObject targetObj) //Not called from anywhere
    {
        CreateStartNode(originObj);
        CreateEndNode(targetObj);
        leadingNode = startNode;
        nodeList.Add(leadingNode);
        FindPathfindWithFloors(originObj, targetObj);
        setUp = true;
    }

    void MoveToTopOfStairs()
    {
        originObj.GetComponent<GameObject>().GetComponent<AICharacter>().Mover(targetStairNode.transform.position);
        //originObj.transform.position = Vector3.MoveTowards(originStairNode.transform.position, targetStairNode.transform.position, originObj.GetComponent<GameObject>().GetComponent<AICharacter>().movementSpeed * Time.deltaTime);

    }

    void FindPathfindWithFloors(GameObject originObj, GameObject targetObj)
    {
        GetFloors(originObj, targetObj);
        CompareFloors(); // Done to see if a traversal of stairs is needed
        if (differentFloors)
        {
            FindStairNodes();
            Pathfind(originObj, originStairNode);//Nothing to move the obj
            MoveObj(nodeList);

            if (CheckArrived(originObj.transform.position, originStairNode.transform.position))
            {
                while (!CheckArrived(originObj.transform.position, targetStairNode.transform.position))
                {
                    MoveToTopOfStairs();
                }
            }
            Pathfind(originObj, finaltargetObj);
        }
    }

    void MoveObj(MyList<NewNode> nodeList)
    {
        for (int i = 0; i < nodeList.ListLength(); i++)
        {
            while (!CheckArrived(originObj.transform.position, nodeList.ReturnData(i).pos))
            {
                originObj.GetComponent<GameObject>().GetComponent<AICharacter>().Mover(nodeList.ReturnData(i).pos);
            }
        }
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

        if (differentFloors && originStairNode != null && targetStairNode != null)
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

    void FindLeadingNode()
    {
        NewNode temp;
        //Hashtable ht = new Hashtable();
        //for (int i = 0; i < 4; i++)
        //{
        //    ht.Add(SourroundingNodes[i].fCost, SourroundingNodes[i]);
        //}
        //leadingNode = ht.get

        //Preforming basic bubble sort to find node with lowest fCost
        for (int o = 0; o < SourroundingNodes.Length - 2; o++)
        {
            for (int t = 0; t < SourroundingNodes.Length - 2; t++)
            {
                if (SourroundingNodes[o].fCost > SourroundingNodes[o + 1].fCost)
                {
                    temp = SourroundingNodes[o + 1];
                    SourroundingNodes[o + 1] = SourroundingNodes[o];
                    SourroundingNodes[o] = temp;
                }
            }
        }

        leadingNode = SourroundingNodes[0];
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
        if (leftNode.isToutchingFloor && NotNullUnder(leftNode.pos))
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

    void CreateStartNode(GameObject originObj)
    {
        this.startNode = new NewNode(originObj);
        Debug.Log("startNode =" + startNode + ", " + startNode.pos);
    }

    void CreateEndNode(GameObject targetObj)
    {
        this.endNode = new NewNode(targetObj);
        Debug.Log("endNode =" + endNode + ", " + endNode.pos);
    }

    //NewNode GetNodeUnder(Vector3 vector3) //shouldn't exist
    //{
    //    NewNode NodeHit;
    //    RaycastHit hit;
    //    Physics.Raycast(vector3, Vector3.down, out hit, Convert.ToInt32(Mathf.Infinity));
    //    NodeHit = hit.collider.gameObject.ge

    //}


    void GetFloors(GameObject originObj, GameObject targetObj)
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
        Debug.Log($"originFloor = {originFloor}");
        Debug.Log($"targetFloor = {targetFloor}");
    }

    void CreateNeighbourNodes()
    {
        Vector3 position = new Vector3(leadingNode.pos.x - 1, leadingNode.pos.y, leadingNode.pos.z);
        GameObject tempObj = new GameObject();
        tempObj.transform.position = position;
        leftNode = new NewNode(tempObj);
        position = new Vector3(leadingNode.pos.x + 1, leadingNode.pos.y, leadingNode.pos.z);
        rightNode = new NewNode(tempObj);
        position = new Vector3(leadingNode.pos.x, leadingNode.pos.y, leadingNode.pos.z + 1);
        upNode = new NewNode(tempObj);
        position = new Vector3(leadingNode.pos.x, leadingNode.pos.y, leadingNode.pos.z - 1);
        downNode = new NewNode(tempObj);
    }

    bool CheckArrived(Vector3 currentPos, Vector3 targetPos)
    {
        if (currentPos == targetPos)
        {
            arrived = true;
        }

        return arrived;
    }

}
