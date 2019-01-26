using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public string prompt;

    public string rectResponse;
    public bool rectReact = true; // if true, rectangle has a 'Reaction' and does not trigger 'rectPrompt' 
    public Beat rectPrompt;

    public string circResponse;
    public bool circReact = true;
    public Beat circPrompt;

    public string triResponse;
    public bool triReact = true;
    public Beat triPrompt;

    public string xResponse;
    public bool xReact = true;
    public Beat xPrompt;
}
