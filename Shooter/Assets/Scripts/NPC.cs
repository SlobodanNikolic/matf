using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : BaseCharacter
{
    public GameObject player;
    public NavMeshAgent navMeshAgent;


    public void MoveToPlayer()
    {
        Debug.Log("Move to player");

        if (player != null && navMeshAgent.isOnNavMesh)
        {
            Debug.Log("Destination set");
            navMeshAgent.SetDestination(player.transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
