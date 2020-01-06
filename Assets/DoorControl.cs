using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    /// <summary>
    /// Need to make sure the player is looking at the door (raycast hitting the door?)
    /// Need to make sure the player is close enough to the door (checkspere at doors center?)
    /// </summary>
    public float openSpeed;
    public float maxAngle;
    public Vector3 direction;

    bool open = false;
    bool close = false;

    // Start is called before the first frame update
    void Start()
    {
        maxAngle = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && open == false)
        {
            close = false;
            open = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && open == true)
        {
            open = false;
            close = true;

        }

        //Check if the angle of the door is equal to the max angle of the door
        if (Mathf.Round(transform.eulerAngles.y) != maxAngle)
        {
            //Rotate Door at the given speed
            transform.Rotate(direction * openSpeed);
        }

        if (open == true)
        {
            maxAngle = 90f;
            direction = Vector3.up;
        }

        if (close == true)
        {
            maxAngle = 0;
            direction = Vector3.up;
        }
    }
}
