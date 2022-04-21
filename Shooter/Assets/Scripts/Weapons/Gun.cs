using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] Bullet bullet;
    [SerializeField] private ParticleSystem muzzleFlash;

    
    public override void Shoot()
    {
        if(Time.time - lastTimeShoot > rateOfFire)
        {
            Bullet tmpBullet = Instantiate(bullet, tipOfTheWeapon.position, tipOfTheWeapon.rotation);
            tmpBullet.Setup(damage);
            muzzleFlash.Play();
            lastTimeShoot = Time.time;
        }
        
    }
}
