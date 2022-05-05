using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 1;
    private void Update()
    {
        if (countdown <= 0f)
        {
            Spawnwave();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    void Spawnwave()
    {


        for(int i =0; i < waveIndex; i++)
        {
            SpawnEnemys();
        }
        waveIndex++;

    }


    void SpawnEnemys()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
