using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScr : MonoBehaviour
{
    public float timeToSpawn = 4;

    int spawnCount = 0;

    public GameObject enemyPrefab, wayPointsParent;
 



    // Update is called once per frame
    void Update()
    {
        if (timeToSpawn <= 0)
            StartCoroutine(SpawnEnemy(spawnCount + 1));

        timeToSpawn -= Time.deltaTime ;
        
    }

    IEnumerator SpawnEnemy(int enemyCount)
    {
        spawnCount++;

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject tmpEnemy = Instantiate(enemyPrefab);
            tmpEnemy.transform.SetParent(gameObject.transform, false);
            tmpEnemy.GetComponent<EnemyScr>().wayPointsParent = wayPointsParent;

            yield return new WaitForSeconds(0.2f);
        }
    }
}
