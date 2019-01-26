using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public Transform Rusher;
    int spawnCount;
    public int spawnReset;

    void Start()
    {
        spawnCount = spawnReset;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spawnCount);
        spawnCount -= 1;
        if (spawnCount == 0)
        {
            spawnCount = spawnReset;
            SpwnRushOneRndm();
        }
    }

    void SpwnRushOneRndm()
    {
        Transform RusherInstance = Instantiate(
            Rusher,
            new Vector3(this.transform.position.x, Random.Range(-4, 4), 0),
            Quaternion.identity
            );
    }
}
