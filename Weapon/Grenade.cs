using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    float countdown;

    public float radius = 5;
    public float explosionForce = 70;

    bool exploded = false;

    public GameObject explosionEffect;

  private AudioSource audioSource;
   public AudioClip explosionSound;
        
     
    
    void Start()
    {

       audioSource=GetComponent<AudioSource>();  
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !exploded)
        {
            Explode();
            exploded = true;
        }
    }

    void Explode()
    {
        // Instantiate the explosion effect at the grenade's position and rotation
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Get all colliders within the specified radius from the grenade's position
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        // Apply explosion force to all rigidbodies within the explosion radius
        foreach (var rangeObjects in colliders)
        {

            AI ai  = rangeObjects.GetComponent<AI>();
            if (ai !=null)
            {
                ai.GrenadeImpact();
            }

            Rigidbody rb = rangeObjects.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce * 10, transform.position, radius);
            }
        }

        audioSource.PlayOneShot(explosionSound);
gameObject.GetComponent<SphereCollider>().enabled = false;
gameObject.GetComponent<MeshRenderer>().enabled = false;
        // Destroy the grenade game object
        Destroy(gameObject,delay*5);
    }
}

