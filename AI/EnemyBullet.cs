using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject,3);
    }

   private void OnCollisionEnter(Collision Collision) 
   {
    if (Collision.gameObject.CompareTag("Player"))
    {
         Destroy(gameObject);
    }
   }
}
