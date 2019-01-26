using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public PolygonCollider2D pc;

    public KeyCode upKey;
    public KeyCode downKey;

    public float pSpd;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(upKey))
        {
            rb.velocity = new Vector2(0, 1);
        }
        if (Input.GetKeyDown(downKey))
        {
            rb.velocity = new Vector2(0, -1);
        }*/

        rb.velocity = new Vector2(Input.GetAxis("LHorizontal")*pSpd, Input.GetAxis("LVertical")*pSpd);

      //  Debug.Log(rb.velocity);
      //  Debug.Log("Vertical: " + Input.GetAxis("LVertical"));
      //  Debug.Log("Horizontal: " + Input.GetAxis("LHorizontal"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("DEAD");
        }
    }
}
