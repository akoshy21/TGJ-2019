using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public Transform Rusher;
    public Transform Wiggler;
    int spawnCount;
    public int spawnReset;
    public float enemySpeed;
    public int wigglerChance;
    int spawnCountStart;
    int spawnResetStart;
    float enemySpeedStart;

    public GameObject player;
    private Player_Controller pc;

    void Start()
    {
        pc = player.GetComponent<Player_Controller>();
        spawnCount = spawnReset;

        spawnCountStart = spawnCount;
        spawnResetStart = spawnReset;
        enemySpeedStart = enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Spawn Count: " + spawnCountStart + "Spawn Reset: " + spawnResetStart + "Enemy Speed: " + enemySpeedStart);
        float enemyChance = Random.Range(0, 100);
        spawnCount -= 1;
        if (spawnCount == 0)
        {
            if(spawnReset > 30)
            {
                spawnReset -= 2;
            }
            if(enemySpeed < 15)
            {
                enemySpeed += 0.2f;
            }
            spawnCount = spawnReset;
            if (enemyChance > wigglerChance)
            {
                SpwnRushOneRndm();
            }
            else
            {
                SpwnWigOneRndm();
            }
        }
        deathState();
        Debug.Log(pc.curLives);
    }

    void deathState()
    {
        if(pc.curLives <= 0)
        {
            enemySpeed = 0;
            spawnCount = spawnReset;
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
    void SpwnWigOneRndm()
    {
        float side = Random.Range(0, 2);
        if(side > 1)
        {
            float spawnpoint = Random.Range(3, 4);
        }
        else
        {
            float spawnpoint = Random.Range(-4, -3);
        }
        Transform WigglerInstance = Instantiate(
            Wiggler,
            new Vector3(this.transform.position.x, Random.Range(-4, 4), 0),
            Quaternion.identity
            );
    }

    public void Reset()
    {
        spawnCount = spawnCountStart;
        spawnReset = spawnResetStart;
        enemySpeed = enemySpeedStart;
    }
}
