using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{
    public bool gameStart = false;

    public GameObject menuManager;
    public GameObject gameManager;
    public GameObject menu;
    public GameObject credits;


    [Header ("Menu")]
    public string curState = "Menu";
    private int menuSelect;
    public SpriteRenderer start;
    public SpriteRenderer credit;
    public Sprite startOff;
    public Sprite startOn;
    public Sprite creditOff, creditOn;

    public bool enterUp = true;

    public float freq;
    private float freqCap;

    // Start is called before the first frame update
    void Start()
    {
        freqCap = freq;
        menuSelect = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return) && !enterUp)
        {
            enterUp = true;
        }

        if (curState == "Menu")
        {
            menu.SetActive(true);
            credits.SetActive(false);

            if (Input.GetAxis("LVertical") > 0.8f && menuSelect == 1 || Input.GetKeyDown(KeyCode.W) && menuSelect == 1)
            {
                Debug.Log("UP");
                menuSelect = 0;
                start.sprite = startOn;
            }
            if (Input.GetAxis("LVertical") < -0.8f && menuSelect == 0 || Input.GetKeyDown(KeyCode.S) && menuSelect == 0)
            {
                menuSelect = 1;
                credit.sprite = creditOn;
            }

            if(menuSelect == 0)
            {
                Blink(start, startOn, startOff, freqCap);
                
                credit.sprite = creditOff;
                if (Input.GetButtonDown("Cross") || (Input.GetKeyDown(KeyCode.Return) && enterUp))
                {
                    curState = "Game";
                    enterUp = false;
                }
            }
            if (menuSelect == 1)
            {
                Blink(credit, creditOn, creditOff, freqCap);
                start.sprite = startOff;
                
                if (Input.GetButtonDown("Cross") || (Input.GetKeyDown(KeyCode.Return) && enterUp))
                {
                    curState = "Credit";
                    enterUp = false;
                }
            }
        }
        else if (curState == "Game")
        {
            gameStart = true;
            menuManager.SetActive(false);
            gameManager.SetActive(true);
        }
        if(curState == "Credit")
        {
            menu.SetActive(false);
            credits.SetActive(true);

            if (Input.GetButtonDown("Circle") || (Input.GetKeyDown(KeyCode.Return) && enterUp))
            {
                Debug.Log("BACKSIES");
                curState = "Menu";
            }
        }
    }

    void Blink(SpriteRenderer me, Sprite one, Sprite two, float freqCap)
    {
        freq -= Time.deltaTime;
        if(freq <= 0)
        {
            freq = freqCap;
            if(me.sprite == one)
            {
                me.sprite = two;
            }else if(me.sprite == two)
            {
                me.sprite = one;
            }
        }
    }
}
