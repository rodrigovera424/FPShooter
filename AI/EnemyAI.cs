

  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public float distanceToFollowPlayer = 10f;
    public float attackDistance = 2f;
    public int meleeDamage = 10;
    public float attackCooldown = 2f;

    private float lastAttackTime;
    private bool isAttacking;

    private void Start()
    {
        // Encontrar al jugador automáticamente si no se asignó manualmente
        if (player == null)
        {
            player = FindObjectOfType<PlayerMovement>().transform;
        }

        lastAttackTime = Time.time;
        isAttacking = false;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si el jugador está lo suficientemente cerca, atacar
        if (distanceToPlayer <= attackDistance)
        {
            if (!isAttacking)
            {
                isAttacking = true;
                AttackPlayer();
            }
        }
        // Si el jugador está en rango de seguimiento, seguirlo
        else if (distanceToPlayer <= distanceToFollowPlayer)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        navMeshAgent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        // Verificar si el ataque está listo (según el cooldown)
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Aquí puedes agregar lógica adicional para la animación o efectos visuales del ataque

            // Reducir la salud del jugador usando el script PlayerInteractions
            PlayerInteractions playerInteractions = player.GetComponent<PlayerInteractions>();
            if (playerInteractions != null)
            {
                playerInteractions.LoseHealth(meleeDamage);
            }

            lastAttackTime = Time.time;
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
    }
}
