using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseCharacter : MonoBehaviour, IDamageable
{
    private int health;
    public int Health { get { return health; } }
    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
