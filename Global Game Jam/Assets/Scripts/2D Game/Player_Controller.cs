using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip ouch;
    public AudioClip Oof;
    public AudioClip goodboy;

    public bool dead;
    int deathcount = 0;

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

    private Vector3 startPos;

    public GameObject enemySpawner;
    private Enemy_Spawner es;

    void Start()
    {
        es = enemySpawner.GetComponent<Enemy_Spawner>();
        startPos = transform.position;
        skore = 0;
        rb = GetComponent<Rigidbody2D>();
        mainCamStart = mainCam.transform.position;
        timeRemain = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (curLives <= 0)
        {
            dead = true;
            rb.velocity = Vector2.zero;
        }
        else
        {
            dead = false;
            skore += 1;
            score.text = ("" + (skore / 10));
            if (ControllerCheck.ControllerConnected)
            {
                rb.velocity = new Vector2(Input.GetAxis("LHorizontal") * pSpd, Input.GetAxis("LVertical") * pSpd);
            }
            else {
                rb.velocity = new Vector2(Input.GetAxis("WASDHorizontal") * pSpd, Input.GetAxis("WASDVertical") * pSpd);
            }
            lives.fillAmount = curLives / maxLives;

            screenShake();
        }
        if(skore % 500 == 0)
        {
            audioPlayer.PlayOneShot(goodboy);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            
            shaking = true;
            curLives -= 1;
            if(curLives > 0)
            {
                audioPlayer.PlayOneShot(ouch);
            }
            else
            {
                audioPlayer.PlayOneShot(Oof);
            }
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

    public void Reset()
    {
        transform.position = startPos;
        curLives = maxLives;
        skore = 0;
        es.Reset();
        dead = false;
        deathcount += 1;
    }
}
