//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CreateMap : MonoBehaviour
//{
//    // https://www.youtube.com/watch?v=AKKpPmxx07w
//    // Start is called before the first frame update
//    void Start()
//    {
//        CreateFloor();
//        CreateNodes();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    CreateNodes()
//    {

//    }

//    CreateFloor()
//    {
//        //https://docs.unity3d.com/ScriptReference/GameObject.CreatePrimitive.html
//        //Create a Floor GameObject that is a cube
//        GameObject Floor001 = GameObject.CreatePrimitive(PrimitiveType.Cube);
//        //Set Floor001 position to 0,0,0
//        Floor001.transform.position = new Vector3(0, 0, 0);
//        //https://docs.unity3d.com/ScriptReference/Transform-localScale.html
//        //Set the scale of the object to be flat but with a length and width of 100
//        float xFloor001 = 100f;
//        float zFloor001 = 100f;
//        Floor001.transform.localscale += new Vector3(xFloor001, 0, zFloor001);
//    }

//}

