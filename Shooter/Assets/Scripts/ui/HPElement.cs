using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPElement : MonoBehaviour
{
    [SerializeField] private Image playerImage;
    [SerializeField] private Image healthBar;
    public bool lockRotation = false;

    public void SetPlayerImage(Sprite image)
    {
        playerImage.sprite = image;
    }

    public void SetHealthBar(float amount, Color barColor)
    {
        healthBar.fillAmount = amount;
        healthBar.color = barColor;
    }
}
