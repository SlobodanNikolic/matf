using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseCharacter
{
    [SerializeField] private  HPElement healthBar;
    void LateUpdate()
    {
        healthBar.SetHealthBar((float)Health/100f, Color.green);
        if (healthBar.lockRotation)
        {
            healthBar.transform.rotation = Quaternion.identity;
        }
    }

}
