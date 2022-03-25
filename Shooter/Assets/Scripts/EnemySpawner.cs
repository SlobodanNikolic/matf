using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public PlayerMovement player;
    public List<GameObject> intantiatedEnemies;
    public int spawnTime;
    public int maxEnemyCount;
    private int enemyCount;

    private Coroutine spawnCoroutine;

    private void Awake()
    {
        intantiatedEnemies = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine(spawnTime));
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnCoroutine(int timeForSpawn)
    {
        System.Random randomIndex = new System.Random();

        while (true) {

            int index = randomIndex.Next(0, spawnPoints.Count);
            Vector3 spawnPosition = spawnPoints[index].position;

            GameObject instantiatedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            intantiatedEnemies.Add(instantiatedEnemy);
            enemyCount++;

            if(enemyCount >= maxEnemyCount)
            {
                yield break;
            }
            
            yield return new WaitForSecondsRealtime(timeForSpawn);

        }

    }
}
