using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : NPC
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float rateOfFire = 2f;
    [SerializeField] int dmgAmount = 1;
    GameObject lockedTarget;
    bool isDead;
    void Start()
    {
        navMeshAgent.speed = moveSpeed;
        navMeshAgent.destination = player.transform.position;
    }
    void Update()
    {
        float velocity = navMeshAgent.velocity.magnitude;
        //animator.SetFloat("MoveSpeed", velocity);
        MoveToPlayer();
    }

    IEnumerator Attack()
    {
        while (lockedTarget != null)
        {
            navMeshAgent.speed = 0;
            //animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.5f); //Small delay for arm to swing
            lockedTarget?.GetComponent<IDamageable>().TakeDamage(dmgAmount);
            yield return new WaitForSeconds(rateOfFire);
            navMeshAgent.speed = moveSpeed;
        }
    }
    public override void Die()
    {
        isDead = true;
        StopAllCoroutines();
        navMeshAgent.enabled = false;
        GetComponent<Collider>().enabled = false;
        //animator.SetTrigger("Death");
        OnDeath(3);
        Destroy(gameObject, 3);
    }
    void OnTriggerEnter(Collider collider)
    {
        IDamageable dmgObj = collider.gameObject.GetComponent<IDamageable>();
        if (dmgObj != null && !collider.gameObject.GetComponent<NPC>())
        {
            lockedTarget = collider.gameObject;
            StartCoroutine(Attack());
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == lockedTarget)
        {
            lockedTarget = null;
        }
    }
}
