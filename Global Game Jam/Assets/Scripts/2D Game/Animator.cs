using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator : MonoBehaviour
{
    public GameObject player;
    private Player_Controller pc;

    public Sprite[] dedSprites;
    public Sprite[] liveSprites;

    public int spriteNum;
    public Sprite[] spriteSeries;
    public SpriteRenderer sr;
    public float maxTime;
    private float mxTime;
    private float curTime;
    private int spriteIndex;
    private bool frameFix;

    void Start()
    {
        mxTime = maxTime;
        frameFix = false;
        pc = player.GetComponent<Player_Controller>();
        sr = GetComponent<SpriteRenderer>();
        //spriteSeries = new Sprite[spriteNum];
        sr.sprite = spriteSeries[0];
        spriteIndex = 0;
        curTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.dead)
        {
            deadAnim();
        }
        else
        {
            spriteSeries = liveSprites;
            maxTime = mxTime;
        }
        sr.sprite = spriteSeries[spriteIndex];
        curTime -= Time.deltaTime;
        if(curTime <= 0)
        {
            curTime = maxTime;
            spriteIndex += 1;
            if(spriteIndex >= spriteSeries.Length)
            {
                if (pc.dead)
                {
                    pc.Reset();
                }
                    spriteIndex = 0;
            }
        }   
    }

    void deadAnim()
    {
        if (!frameFix)
        {
            frameFix = true;
            curTime = .6f;
        }
        spriteSeries = dedSprites;
        sr.sprite = spriteSeries[0];
        maxTime = .6f;
    }
}
