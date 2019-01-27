using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggler_Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public CircleCollider2D cc;

    public GameObject enemySpawner;
    Enemy_Spawner spawner;

    public float speed;

    public float ydir = 0;

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
        if (transform.position.y > 0)
        {
            ydir -= 0.3f;
        }
        if(transform.position.y < 0)
        {
            ydir += 0.3f;
        }
        if (speed <= 0)
        {
            Destroy(gameObject);
        }
        rb.velocity = new Vector2(-1 * speed/2.0f, ydir);
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
