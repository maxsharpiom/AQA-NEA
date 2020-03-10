using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Level1Boss : Enemy
{    
    void Start()
    {
        this.maxHealth = 3000f;
        this.movementSpeed = 3f;
        this.viewDistance = 100f;
        //this.weapon = new Hand("Level1BossHand", this.gameObject.transform.position, false); //Give the boss a weapon
        this.weapon.damage = 10f; //make the damage dealt by this instance of the weapon greater
        int numberOfWolves = 8;
        SpawnInWolves(numberOfWolves);
        ScaleBoss();                
    }
    
    void ScaleBoss()
    {
        float scaleAmmount = 3;
        this.gameObject.transform.localScale += new Vector3(scaleAmmount, scaleAmmount,scaleAmmount);
    }

    void SpawnInWolves(int numberOfWolves)
    {
        //The distance a wolf spawns from the central point of the boss
        float spawnBufferDistance = 7.5f;
        Vector3 spawnPosition;
        float cumlativeDegreeOfSpawn = 0;
        float degreeSeperationBetweenEachWolf = 360 / numberOfWolves;
        //Use rcos(x) and rsin(x) for each position        

        //Spawn wolfs dynamically around boss
        for (int i = 0; i < numberOfWolves; i++)
        {
            //Instantiate a new wolf
            RadioactiveWolf wolf = new RadioactiveWolf();
            wolf.transform.position = new Vector3(spawnBufferDistance*Mathf.Sin(cumlativeDegreeOfSpawn),spawnBufferDistance*Mathf.Cos(cumlativeDegreeOfSpawn),this.transform.position.z);
            //Instantiate wolf into game world
            Instantiate(wolf);
            cumlativeDegreeOfSpawn += degreeSeperationBetweenEachWolf;
        }

    }

}
