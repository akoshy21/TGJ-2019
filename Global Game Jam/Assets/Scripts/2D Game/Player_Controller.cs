using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public Image lives;
    public float curLives;
    public float maxLives;

    public Rigidbody2D rb;
    public PolygonCollider2D pc;

    public KeyCode upKey;
    public KeyCode downKey;

    public float pSpd;

    public Text score;
    private int skore;

    //Screen Shake Stuff
    public GameObject mainCam;
    private Vector3 mainCamStart = new Vector3(0, 0, 0);
    private bool shaking = false;
    private float timeRemain = 0;
    private float maxTime = .1f;

    float magnitude = 0f;

    void Start()
    {
        skore = 0;
        rb = GetComponent<Rigidbody2D>();
        mainCamStart = mainCam.transform.position;
        timeRemain = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        skore += 1;
        score.text = ("" + (skore / 10));
        rb.velocity = new Vector2(Input.GetAxis("LHorizontal")*pSpd, Input.GetAxis("LVertical")*pSpd);
        lives.fillAmount = curLives / maxLives;

        screenShake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("DEAD");
            shaking = true;
            curLives -= 1;
        }
    }

    private void screenShake ()
    {
        magnitude = timeRemain + .2f;

        if (shaking)
        {
            mainCam.transform.position = Vector3.MoveTowards
                (
                    mainCam.transform.position,
                    new Vector3(mainCamStart.x + Random.Range(-1f, 1f), mainCamStart.y + Random.Range(-1f, 1f), mainCamStart.z),
                    magnitude
                );

            timeRemain -= Time.deltaTime;

            if (timeRemain <= 0)
            {
                shaking = false;
                timeRemain = maxTime;
                mainCam.transform.position = mainCamStart;
            }
        }
    }
}
