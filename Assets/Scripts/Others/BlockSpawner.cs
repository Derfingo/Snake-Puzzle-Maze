using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject BlockPrefab;

    public float timeBetweenWaves = 1f;

    private float timeToSpawn = 2f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }

    private void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, SpawnPoints.Length);

        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(BlockPrefab, SpawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
