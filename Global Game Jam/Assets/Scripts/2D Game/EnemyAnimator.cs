using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public int spriteNum;
    public Sprite[] spriteSeries;
    public SpriteRenderer sr;
    public float maxTime;
    private float curTime;
    private int spriteIndex;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //spriteSeries = new Sprite[spriteNum];
        sr.sprite = spriteSeries[0];
        spriteIndex = 0;
        curTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        sr.sprite = spriteSeries[spriteIndex];
        curTime -= Time.deltaTime;
        if (curTime <= 0)
        {
            curTime = maxTime;
            spriteIndex += 1;
            if (spriteIndex >= spriteSeries.Length)
            {
                spriteIndex = 0;
            }
        }
    }
}
