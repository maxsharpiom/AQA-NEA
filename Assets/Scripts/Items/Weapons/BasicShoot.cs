using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShoot : MonoBehaviour
{

    public Camera playerCamera;

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 100))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
