using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject BlockPrefab;

    private void Start()
    {
        
    }

    private void Update()
    {
        SpawnBlocks();
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
