using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Boss : Enemy
{    
    void Start()
    {
        this.maxHealth = 3000f;
        this.movementSpeed = 3f;
        this.viewDistance = 100f;
        this.weapon = new Hands("Level1BossHands", this.gameObject.position, false); //Give the boss a weapon
        this.Hands.damage = 10f; //make the damage dealt by this instance of the weapon greater
        int numberOfWolves;
        SpawnInWolves(numberOfWolves);
        ScaleBoss();                
    }
    
    void ScaleBoss()
    {
        float scaleAmmount = 3;
        this.gameObject.transform.localscale += new Vector3(scaleAmmount, scaleAmmount,scaleAmmount);
    }

    void SpawnInWolves(int numberOfWolves)
    {
        numberOfWolves = 4;
        //The distance a wolf spawns from the central point of the boss
        float spawnBufferDistance = 7.5f;
        Vector3 spawnPosition;
        //float cumlativeDegreeOfSpawn = 0;
        //float degreeSeperationBetweenEachWolf;
        //Use rcos(x) and rsin(x) for each position
        //Create a wolf array and set the position of each wolf
        //SPAWNS ARE NOT DYNAMICALLY ADAPTED FOR > 4 WOLFS TO SPAWN
        RadioactiveWolf[] wolf = new RadioactiveWolf[numberOfWolves];
        spawnPosition = new Vector3(this.gameObject.transform.position.x-spawnBufferDistance,this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        wolf[0].transform.position = spawnPosition;
        spawnPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+spawnBufferDistance, this.gameObject.transform.position.z);
        wolf[1].transform.position = spawnPosition;
        spawnPosition = new Vector3(this.gameObject.transform.position.x+spawnBufferDistance, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        wolf[2].transform.position = spawnPosition;
        spawnPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y-spawnBufferDistance, this.gameObject.transform.position.z);
        wolf[3].transform.position = spawnPosition;

        //Instantiate wolfs
        for (int i = 0; i < wolf.Length; i++)
        {
            Instanantiate(wolf[i], wolf[i].transform.position);
        }

        //cumlativeDegreeOfSpawn += degreeSeperationBetweenEachWolf;
        
    }

}
