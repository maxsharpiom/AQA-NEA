using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(playerPrefab, transform.position, transform.rotation);
    }
}
