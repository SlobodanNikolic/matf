using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    public float moveSpeed = 1;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Igrac");
        if(player == null)
        {
            Debug.LogError("Plejer je null");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemy start");
        navMeshAgent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }
}
