using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3 spawnPos; //spawn position
    public float spawnRangeX; //range between which animals will be spawned
    public float spawnRangeY; //Y coordinate of spawn
    public float startDelay;
    public float spawnInterval;
    public GameObject villager;
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
        spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY), 0);

        //instantiate based on index of randomly generated index
        Instantiate(villager, spawnPos, villager.transform.rotation);
    }
}
