using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    protected float maxHealth; //maxHealth may need to be mathF.Infinity to make a climbable object
    public float currentHealth;
    protected string name;
    protected bool explodes;
    protected bool containsItem;
    protected Item containingInside; //Might need to be more specific with the type as Item is the base and not the class of the actual item itself
    protected float explosionRadius;
    protected float maximumDamage; //Damage dealt per meter radius;
    //Need to referene player for position;
    protected bool canPickup;
    protected Vector3 position;

    private void Start()
    {
        this.gameObject.tag = "canTakeDamage";
    }

    protected void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy();
        }
    }
    
    void Destroy()
    {
        if (this.explodes == true)
        {
            Explode();
        }
        if (this.containsItem == true)
        {
            //Drop containing item
            DropContainingItem();
        }

        //Remove gameObject from world
        Object.Destroy(this.gameObject);
    }

    void Explode()
    {
        float dealDamageToSourounding;
        //Returns true if there are any colliders overlapping the sphere
        Collider[] explosionHit = Physics.OverlapSphere(this.transform.position, explosionRadius);
        float distanceToPlayerSquared;

        //Inverse square law
        for (int i = 0; i < explosionHit.Length; i++)
        {
            distanceToPlayerSquared = Vector3.Distance(explosionHit[i].transform.position, this.transform.position);
            dealDamageToSourounding = maximumDamage * (1 / distanceToPlayerSquared);
            explosionHit[i].SendMessage("TakeDamage", dealDamageToSourounding);
        }
        //play explosion anim
    }

    void DropContainingItem()
    {
        //Spawn item in and set position equal to the destructable object
        Instantiate(containingInside, this.transform);
        //May need to apply gravity?
    }

}


