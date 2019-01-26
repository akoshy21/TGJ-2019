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
        speed = spawner.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-1 * speed, 0);
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
