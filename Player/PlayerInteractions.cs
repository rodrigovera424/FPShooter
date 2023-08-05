using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform startPosition;

    private void OnTriggerEnter(Collider other)
    {
        // ... otros códigos ...

        if (other.gameObject.CompareTag("DeathFloor"))
        {
            // Perder vida
            LoseHealth(5);

            // ... otros códigos ...
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            // Perder vida
            LoseHealth(5);
        }
    }

    // Cambiar el nivel de protección de private a public
    public void LoseHealth(int damageAmount)
    {
        // Reducir la salud del jugador según el daño recibido
        // Puedes agregar aquí cualquier otra lógica adicional que necesites

        GameManager.Instance.LoseHealth(damageAmount);
    }
}