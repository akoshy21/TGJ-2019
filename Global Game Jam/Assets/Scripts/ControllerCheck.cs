using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ControllerCheck : MonoBehaviour
{
    public static bool ControllerConnected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetJoystickNames().Length > 0)
        {
            ControllerConnected = true;
        }
        else
        {
            ControllerConnected = false;
        }
    }
}
