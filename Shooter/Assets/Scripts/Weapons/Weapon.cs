using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float rateOfFire;
    [SerializeField] protected Transform tipOfTheWeapon;
    [SerializeField] protected int damage;

    [SerializeField] protected float lastTimeShoot;

    public virtual void Shoot()
    {
             
    }
}
