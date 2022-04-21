using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{
    public Sprite enemyImage;
    [SerializeField] private  HPElement healthBar;
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
        Debug.Log("Enemy start"+"HP="+Health);
        navMeshAgent.speed = moveSpeed;
        healthBar.SetPlayerImage(enemyImage);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }

    void LateUpdate()
    {
        healthBar.SetHealthBar((float)Health/100f, Color.red);
        if (healthBar.lockRotation)
        {
            healthBar.transform.rotation = Quaternion.identity;
        }
    }
}
