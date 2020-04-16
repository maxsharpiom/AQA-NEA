using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : DestructableObject
{

    void Start()
    {
        this.maxHealth = 20f;
        this.currentHealth = maxHealth;
        this.name = "ExplosiveBarrel";
        this.explodes = true;
        this.containsItem = false;
        this.explosionRadius = 10f;
        this.maximumDamage = 80f;
        this.destroyAudioName = "explode";
    }

    private void Awake()
    {
        this.gameObject.AddComponent<AudioSource>();
        this.destroySource = this.gameObject.GetComponent<AudioSource>();
        this.destroySource.clip = Resources.Load<AudioClip>(destroyAudioName);
        this.destroySource.playOnAwake = false;
        this.gameObject.tag = "CanTakeDamage";        
    }

    public ExplosiveBarrel(Vector3 position)
    {
        this.position = position;
    }

}


