
    


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class AI : MonoBehaviour
// {
//     public NavMeshAgent navMeshAgent;
//     public Transform[] destinations;
//     public float distanceToFollowPath = 2;

//     private int i = 0;
//     [Header("---------Followplayer------")]
//     public bool followPlayer;

//     private GameObject player;

//     private float distanceToPlayer;
//     public float distanceToFollowPlayer = 10;

//     void Start()
//     {
//         if (destinations==null || destinations.Length ==0) ;
//         // {
//         //    TransformBlock.gameObject.GetComponent<AI> ().enable=false;
//         // }
//         else 
//         {
//             navMeshAgent.destination = destinations[0].transform.position;
//         }

//         GameObject playerObject = FindObjectOfType<PlayerMovement>().gameObject;
//         if (playerObject != null)
//         {
//             player = playerObject;
//         }
//     }

//     void Update()
//     {
//         if (player != null)
//         {
//             distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

//             if (distanceToPlayer <= distanceToFollowPlayer && followPlayer)
//             {
//                 FollowPlayer();
//             }
//             else
//             {
//                 EnemyPath();
//             }
//         }
//     }

//     public void EnemyPath()
//     {
//         if (destinations.Length > 0)
//         {   
//             navMeshAgent.destination = destinations[i].position;

//             if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath)
//             {
//                 if (i < destinations.Length - 1)
//                 {
//                     i++;
//                 }
//                 else
//                 {
//                     i = 0;
//                 }
//             }
//         }
//     }

//     public void FollowPlayer()
//     {
//         navMeshAgent.destination = player.transform.position;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    public float distanceToFollowPath = 2;

    private int i = 0;
    [Header("---------Followplayer------")]
    public bool followPlayer;

    private GameObject player;

    private float distanceToPlayer;
    public float distanceToFollowPlayer = 10;

    void Start()
    {
        if (destinations == null || destinations.Length == 0)
        {
            // TransformBlock.gameObject.GetComponent<AI> ().enable=false;
        }
        else
        {
            navMeshAgent.destination = destinations[0].position;
        }

        GameObject playerObject = FindObjectOfType<PlayerMovement>().gameObject;
        if (playerObject != null)
        {
            player = playerObject;
        }
    }

    void Update()
    {
        if (player != null)
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= distanceToFollowPlayer && followPlayer)
            {
                FollowPlayer();
            }
            else
            {
                EnemyPath();
            }
        }
    }

    // public void EnemyPath()
    // {
    //     if (destinations.Length > 0)
    //     {
    //         navMeshAgent.destination = destinations[i].position;

    //         if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath)
    //         {
    //             if (i < destinations.Length - 1)
    //             {
    //                 i++;
    //             }
    //             else
    //             {
    //                 i = 0;
    //             }
    //         }
    //     }
    // }
     public void EnemyPath()
    {
      
        {
            navMeshAgent.destination = destinations[i].position;

            if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath)
            {
                if (destinations [i]!= destinations  [destinations.Length - 1 ])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
        }
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }

    public void GrenadeImpact()
    {
        Destroy(gameObject);
    }
}