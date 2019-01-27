using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CameraMovement : MonoBehaviour
{
    public float rBound;
    public float lBound;

    public bool TV = true;

    private float startRotate;
    // Start is called before the first frame update
    void Start()
    {
        startRotate = transform.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("RHorizontal");
        float vertical = Input.GetAxis("RVertical");

   
        if (transform.eulerAngles.y > rBound && transform.eulerAngles.y < 120) 
            TV = false;
        else
        {
            TV = true;
        }
        
        if (TV)
        {
            if (transform.eulerAngles.y < 180)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.Euler(transform.eulerAngles.x, horizontal * 80, 0),
                    1.5f * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.Euler(vertical * 15 + startRotate, transform.eulerAngles.y, 0),
                    5.5f * Time.deltaTime);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
           }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.Euler(transform.eulerAngles.x, horizontal * 20, 0),
                    7.5f * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation,
                    Quaternion.Euler(vertical * 15 + startRotate, transform.eulerAngles.y, 0),
                    5.5f * Time.deltaTime);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
        }
        if (!TV)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(transform.eulerAngles.x, (horizontal * 40) +60, 0),
                2.5f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.Euler(vertical * 15 + startRotate, transform.eulerAngles.y, 0),
                5.5f * Time.deltaTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
        
    }
}

