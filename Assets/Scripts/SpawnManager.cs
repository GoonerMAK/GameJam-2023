using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3 spawnPos; //spawn position
    public float minSpawnX; //range between which animals will be spawned
    public float maxSpawnX;
    public float minSpawnY; //Y coordinate of spawn
    public float maxSpawnY;
    public float startDelay;
    public float spawnInterval;
    public GameObject[] villagerPrefabs;
    public int villagerIndex;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomVillager", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomVillager()
    {
        villagerIndex = Random.Range(0, villagerPrefabs.Length);

        spawnPos = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), 0);

        //instantiate based on index of randomly generated index
        Instantiate(villagerPrefabs[villagerIndex], spawnPos, villagerPrefabs[villagerIndex].transform.rotation);
    }
}
