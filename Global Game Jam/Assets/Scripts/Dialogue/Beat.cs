﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat
{
    public string prompt;

    public int rCount;
    public float delay;
    public float rDelay = 3;

    public string rectResponse;
    public bool rectReact = true; // if true, rectangle has a 'Reaction' and does not trigger 'rectPrompt' 
    public string rectReaction;
    public Beat rectPrompt;

    public string circResponse;
    public bool circReact = true;
    public string circReaction;
    public Beat circPrompt;

    public string triResponse;
    public bool triReact = true;
    public string triReaction;
    public Beat triPrompt;

    public string xResponse;
    public bool xReact = true;
    public string xReaction;
    public Beat xPrompt;

    public AudioClip clip;

    public Beat(string p, int r, string rr, string rreaction, float d)
    {
        prompt = p;
        rCount = r;
        delay = d;

        rectResponse = rr;
        rectReaction = rreaction;
    }

    public Beat(string p, int r, string rr, string rreaction, string cr, string creaction, float d)
    {
        prompt = p;
        rCount = r;
        delay = d;

        rectResponse = rr;
        rectReaction = rreaction;
        circResponse = cr;
        circReaction = creaction;
    }

    public Beat(string p, int r, string rr, string rreaction, string cr, string creaction, string tr, string treaction, float d)
    {
        prompt = p;
        rCount = r;
        delay = d;

        rectResponse = rr;
        rectReaction = rreaction;
        circResponse = cr;
        circReaction = creaction;
        triResponse = tr;
        triReaction = treaction;
    }

    public Beat(string p, int r, string rr, string rreaction, string cr, string creaction, string tr, string treaction, string xr, string x_reaction, float d)
    {
        prompt = p;
        rCount = r;
        delay = d;

        rectResponse = rr;
        rectReaction = rreaction;
        circResponse = cr;
        circReaction = creaction;
        triResponse = tr;
        triReaction = treaction;
        xResponse = xr;
        xReaction = x_reaction;
    }
}
