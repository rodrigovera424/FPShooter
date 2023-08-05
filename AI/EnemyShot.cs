using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform SpawnBulletPoint;
    private Transform PlayerPosition;
    public float bulletVelocity = 100;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = FindObjectOfType<PlayerMovement>().transform;
        Invoke("ShootPlayer", 3);
    }

    void OnDestroy()
    {
        // Cancela todas las invocaciones pendientes asociadas a este objeto del script EnemyShot.
        CancelInvoke();
    }

    void ShootPlayer()
    {
        Vector3 playerDirection = PlayerPosition.position - transform.position;

        GameObject newBullet;
        newBullet = Instantiate(enemyBullet, SpawnBulletPoint.position, SpawnBulletPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Force);
        Invoke("ShootPlayer", 3);
    }
}
