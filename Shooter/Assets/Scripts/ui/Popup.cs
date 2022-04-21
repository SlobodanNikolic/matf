using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private HPElement playerHealthBAr;
    [SerializeField] private RectTransform contentHolder;
    [SerializeField] private Sprite playerImage;
    [SerializeField] private Color playerHealthColor;
    [SerializeField] private Sprite enemyImage;
    [SerializeField] private Color enemyHealthColor;
    Enemy[] enemies = new Enemy[0];
    List<HPElement> enemyBars = new List<HPElement>();
    void OnEnable()
    {
        Player player = GameObject.FindGameObjectWithTag("Igrac").GetComponent<Player>();
        playerHealthBAr.SetPlayerImage(playerImage);
        playerHealthBAr.SetHealthBar((float)player.Health/100f, playerHealthColor);

        enemies = GameObject.FindObjectsOfType<Enemy>();

        for (int i = 0; i < enemies.Length; i++)
        {
            HPElement newEnemyBar = Instantiate(playerHealthBAr, contentHolder);
            newEnemyBar.SetPlayerImage(enemyImage);
            newEnemyBar.SetHealthBar((float)enemies[i].Health/100f, enemyHealthColor);
            enemyBars.Add(newEnemyBar);
        }
    }

    void OnDisable()
    {
        for (int i = enemyBars.Count-1; i >= 0; i--)
        {
            Destroy(enemyBars[i].gameObject);
        }
        enemies = new Enemy[0];
        enemyBars = new List<HPElement>();
    }

}
