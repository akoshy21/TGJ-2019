using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_Enemy : MonoBehaviour
{

    public Rigidbody2D rb;
    public CircleCollider2D cc;

    public GameObject enemySpawner;
    Enemy_Spawner spawner;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemySpawner = GameObject.Find("Spawner");
        spawner = enemySpawner.GetComponent<Enemy_Spawner>();      
    }

    // Update is called once per frame
    void Update()
    {
        speed = spawner.enemySpeed;
        rb.velocity = new Vector2(-1 * speed, 0);
        if(speed <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {       
            if (collision.tag == "Border")
            {
            Debug.Log("exit");
            Destroy(gameObject);
            }
    }

}
