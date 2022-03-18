using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPC : BaseCharacter
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected Animator animator;
    [SerializeField] protected NavMeshAgent navMeshAgent;
    protected bool isPlayerInRadius;
    public delegate void Death(int points);
    public static event Death onDeath;
    public void Initialize(GameObject player)
    {
        this.player = player;
    }
    protected void MoveToPlayer()
    {
        if (player != null && navMeshAgent.isOnNavMesh)
        {
            //if (!navMeshAgent.hasPath)
            //{
            navMeshAgent.SetDestination(player.transform.position);
            //}
            //if (navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial
            //    && Vector3.Distance(navMeshAgent.pathEndPosition, player.transform.position) > 1)
            //{
            //    navMeshAgent.SetDestination(player.transform.position);
            //}
        }
    }
    // We need this protected invoking method because onDeath event can't be on left hand side in classes inheriting this one
    protected void OnDeath(int points)
    {
        Death onDeathTemp = onDeath;
        if (onDeathTemp != null)
        {
            onDeathTemp.Invoke(points);
        }
    }
}
