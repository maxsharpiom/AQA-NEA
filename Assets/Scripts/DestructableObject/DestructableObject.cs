using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject
{
    protected float maxHealth;
    protected float currentHealth;
    protected string name;
    protected bool explodes;
    protected bool containsItem;
    protected Item containingInside; //Might need to be more specific with the type as Item is the base and not the class of the actual item itself
    protected bool explosionRadius;
    protected bool maximumDamage; //Damage dealt per meter radius;
    //Need to referene player for position;

    protected void Update()
    {

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
        Collider[] explosionHit = Physics.OverlapSphere(this.position, explosionRadius);
        float distanceToPlayerSquared;

        //Inverse square law
        for (int i = 0; i < explosionHit.Length; i++)
        {
            distanceToPlayerSquared = Vector3.distance(explosionHit.position, this.transform.position);
            dealDamageToSourounding = maximumDamage * (1 / distanceToPlayerSquared);
            explosionHit.SendMessage("TakeDamage", dealDamageToSourounding);
        }
        //play explosion anim
    }

    void DropContainingItem()
    {
        //Spawn item in and set position equal to the destructable object
        Instantiate(containsItem, this.transform.position);
        //May need to apply gravity?
    }

}


