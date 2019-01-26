using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Beat[] story;

    // Start is called before the first frame update
    void Start()
    {
        InitStory();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitStory()
    {
        story = new Beat[10];

        BeatZero();
        BeatOne();

        

    }

    void BeatZero()
    {
        story[0] = new Beat(
            "...Are you hungry?",
            4,
            "Uh...Not really.",
            "You could pretend to be.",
            "...What?",
            "Like, do you wanna get food?",
            "Now that you mention it...",
            null,
            "Gimme like ten minutes.",
            "I’ll starve by then. Do you want that blood on your hands?"
            );

        story[0].triReact = false;
        story[0].triPrompt = new Beat(
            "We should go to 7/11.",
            2,
            "We go there a lot.",
            "Yeah: we’re garbage people!",
            "I’m down, gimme one sec.",
            "Uhuh"
            );
    }

    void BeatOne()
    {
        story[1] = new Beat(
            "Can we go to 7/11?",
            4,
            "Sure.",
            "Awesome, let me grab some stuff.",
            "Not really.",
            "Oh...Guess I’ll go alone.",
            "Let me finish this first.",
            "Okay.",
            "You just asked me like, 4 seconds ago.",
            "I’m still hungry."
            );
    }

    void BeatTwo()
    {
        story[2] = new Beat("Damn it. I don’t have any cash.",
            2,
            "So no on the taquitos?",
            null,
            "Lol same.",
            null);

        story[2].rectReact = false;
        story[2].rectPrompt = new Beat(
            "*Sigh* Do you have any cash?",
            1,
            "Nope",
            null
            );

        story[2].rectPrompt.rectReact = false;
        story[2].rectPrompt.rectPrompt = new Beat(
            "Guess I’ll die, then!",
            1,
            "*Gargle sympathetically*",
            "You're a freak!"
            );

        story[2].circPrompt = new Beat(
            "*Groans*",
            2,
            "*Gargle sympathetically*",
            "You’re a freak!",
            "...",
            null
            );

    }
}
