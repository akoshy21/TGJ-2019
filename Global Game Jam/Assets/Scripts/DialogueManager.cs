using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Beat[] story;
    public int response;

    public int beatIndex = 0;
    public Beat previousBeat;
    public Beat currentBeat;
    public bool start = true;

    public Text prompt;

    public Button rectButton;
    public Text rbText;

    public Button circButton;
    public Text cbText;

    public Button triButton;
    public Text tbText;

    public Button xButton;
    public Text xbText;

    bool asked711;
    bool allowInputRect = true;
    bool allowInputCirc = true;
    bool allowInputTri = true;
    bool allowInputX = true;

    // Start is called before the first frame update
    void Start()
    {
        InitStory();
        UpdateText();

        // StartCoroutine(TimedStart()); REMEMBER TO UNCOMMENT
    }

    // Update is called once per frame
    void Update()
    {
        if (start) {
            StartCoroutine(CheckInput());
        }

    }

    void CheckStart()
    {
        if (!start)
        {
            // write code to detect 2 collisions or access count in other script and then start dialogue.
        }

    }

    IEnumerator TimedStart()
    {
        yield return new WaitForSeconds(5);
        if (!start)
        {
            start = true;
        }
        Debug.Log(start);
    }

    void UpdateText()
    {

            prompt.text = currentBeat.prompt;
            rbText.text = currentBeat.rectResponse;
            cbText.text = currentBeat.circResponse;
            tbText.text = currentBeat.triResponse;
            xbText.text = currentBeat.xResponse;

            ////prompt.gameObject.SetActive(true);
            ////rectButton.gameObject.SetActive(true);
            ////circButton.gameObject.SetActive(true);
            ////triButton.gameObject.SetActive(true);
            ////xButton.gameObject.SetActive(true);
    }

    IEnumerator CheckInput()
    {
        if (allowInputRect)
        {
            if (Input.GetButtonDown("Square") || Input.GetKeyDown("a"))
            {
                if (!currentBeat.rectReact)
                {
                    ActivateButtons(false);
                    yield return new WaitForSeconds(2);
                    MoveBeat(currentBeat.rectPrompt);
                    ActivateButtons(true);
                }
                else
                {
                    beatIndex++;

                    ActivateButtons(false);
                    prompt.text = currentBeat.rectReaction;
                    Debug.Log(currentBeat.rectReaction);
                    yield return new WaitForSeconds(currentBeat.delay);
                    MoveBeat(story[beatIndex]);
                    ActivateButtons(true);
                }
            }
        }
        if (allowInputCirc)
        {
            if (Input.GetButtonDown("Circle") || Input.GetKeyDown("d"))
            {
                if (!currentBeat.circReact)
                {
                    ActivateButtons(false);
                    yield return new WaitForSeconds(2);
                    MoveBeat(currentBeat.circPrompt);
                    ActivateButtons(true);
                }
                else
                {
                    beatIndex++;

                    ActivateButtons(false);
                    prompt.text = currentBeat.circReaction;
                    yield return new WaitForSeconds(currentBeat.delay);
                    MoveBeat(story[beatIndex]);
                    ActivateButtons(true);
                }
            }
        }
        if (allowInputTri)
        {
            if (Input.GetButtonDown("Triangle") || Input.GetKeyDown("w"))
            {
                if (beatIndex == 0)
                {
                    asked711 = true;
                }

                if (!currentBeat.triReact)
                {
                    ActivateButtons(false);
                    yield return new WaitForSeconds(2);
                    MoveBeat(currentBeat.triPrompt);
                    ActivateButtons(true);
                }
                else
                {
                    beatIndex++;

                    ActivateButtons(false);
                    prompt.text = currentBeat.triReaction;
                    yield return new WaitForSeconds(currentBeat.delay);
                    MoveBeat(story[beatIndex]);
                    ActivateButtons(true);
                }
            }
        }
        if (allowInputX)
        {
            if (Input.GetButtonDown("Cross") || Input.GetKeyDown("s"))
            {
                if (!currentBeat.xReact)
                {
                    ActivateButtons(false);
                    yield return new WaitForSeconds(2);
                    MoveBeat(currentBeat.xPrompt);
                    ActivateButtons(true);
                }
                else
                {
                    beatIndex++;

                    ActivateButtons(false);
                    prompt.text = currentBeat.xReaction;
                    yield return new WaitForSeconds(currentBeat.delay);
                    MoveBeat(story[beatIndex]);
                    ActivateButtons(true);
                }
            }
        }
    }

    void ActivateButtons(bool yes)
    {
        if (!asked711)
        {
            story[1].rCount = 2;
        }

        if (yes)
        {
            if (currentBeat.rCount >= 1)
            {
                rectButton.gameObject.SetActive(true);
                allowInputRect = true;
            }
            if (currentBeat.rCount >= 2)
            {
                circButton.gameObject.SetActive(true);
                allowInputCirc = true;
            }
            if (currentBeat.rCount >= 3)
            {
                triButton.gameObject.SetActive(true);
                allowInputTri = true;
            }
            if (currentBeat.rCount >= 4)
            {
                xButton.gameObject.SetActive(true);
                allowInputX = true;
            }
        }
        else
        {
            AllowInput(false);
            rectButton.gameObject.SetActive(false);
            circButton.gameObject.SetActive(false);
            triButton.gameObject.SetActive(false);
            xButton.gameObject.SetActive(false);
        }
    }

    void AllowInput(bool yeet)
    {
        if (!yeet)
        {
            allowInputRect = false;
            allowInputCirc = false;
            allowInputTri = false;
            allowInputX = false;
        }
        else if (yeet)
        {
            allowInputRect = true;
            allowInputCirc = true;
            allowInputTri = true;
            allowInputX = true;
        }
    }

    void MoveBeat(Beat nextBeat)
    {

        previousBeat = currentBeat;
        currentBeat = nextBeat;

        UpdateText();
    }

    void InitStory()
    {
        story = new Beat[10];

        BeatZero();
        BeatOne();
        BeatTwo();
        BeatThree();
        BeatFour();
        BeatFive();

        currentBeat = story[0];
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
            "I’ll starve by then. Do you want that blood on your hands?",
            3
            );

        story[0].triReact = false;
        story[0].triPrompt = new Beat(
            "We should go to 7/11.",
            2,
            "We go there a lot.",
            "Yeah: we’re garbage people!",
            "I’m down, gimme one sec.",
            "Uhuh",
            4
            );
    }

    void BeatOne()
    {
        story[1] = new Beat(
            "Can we go to 7/11?",
            3,
            "Sure.",
            "Awesome, let me grab some stuff.",
            "Not really.",
            "Oh...Guess I’ll go alone.",
            "Let me finish this first.",
            "Okay.",
            "You just asked me like, 4 seconds ago.",
            "I’m still hungry.",
            3
            );
    }

    void BeatTwo()
    {
        story[2] = new Beat("Damn it. I don’t have any cash.",
            2,
            "So no on the taquitos?",
            null,
            "Lol same.",
            null,
            10
            );

        story[2].rectReact = false;
        story[2].rectPrompt = new Beat(
            "*Sigh* Do you have any cash?",
            1,
            "Nope",
            null,
            10
            );

        story[2].rectPrompt.rectReact = false;
        story[2].rectPrompt.rectPrompt = new Beat(
            "Guess I’ll die, then!",
            1,
            "*Gargle sympathetically*",
            "You're a freak!",
            10
            );

        story[2].circReact = false;
        story[2].circPrompt = new Beat(
            "*Groans*",
            2,
            "*Gargle sympathetically*",
            "You’re a freak!",
            "...",
            null,
            10
            );
    }

    void BeatThree()
    {
        story[3] = new Beat(
            "How’s the game going?",
            3,
            "Great",
            "Cool. Cool...",
            "*Sarcastic* Great.",
            null,
            "Surprisingly hard?",
            null,
            1
            );

        story[3].circReact = false;
        story[3].circPrompt = new Beat(
            "Yeah that’s cause you’re not a real gamer.",
            2,
            "I’m so sorry father.",
            "*Croaks*",
            "YOU’RE not a real gamer!",
            null,
            15
            );

        story[3].triReact = false;
        story[3].triPrompt = new Beat(
            "*Looks Expectantly*",
            2,
            "I think this game’s just bad.",
            "Sure you’re not just bad at it?",
            "I dunno. I should try dying less, right?",
            "*Nods* Video games.",
            15
            );
    }

    void BeatFour()
    {
        story[4] = new Beat(
            "So... Uh... I think Alex’s gonna break up with me?",
            4,
            "Oh man... I’m so sorry.",
            "Yeah... it’s been fun.",
            "Wait, what?",
            null,
            "Welp.",
            "Welp indeed.",
            "...",
            null,
            8
            );

        story[4].circReact = false;
        story[4].circPrompt = new Beat(
                "...",
                2,
                "Are you okay?",
                "Yeah...Maybe. I don't know.",
                "...",
                null,
                8
            );
    }

    void BeatFive()
    {
        story[5] = new Beat(
                "...",
                2,
                "What're you gonna do?",
                null,
                "Do you know why?",
                "That's the worst part.",
                5
            );

        story[5].rectReact = false;
        story[5].rectPrompt = new Beat(
                "Ya know what the worst part is?",
                2,
                "...What?",
                null,
                "...",
                null,
                1
            );

        story[5].rectPrompt.rectReact = false;
        story[5].rectPrompt.rectPrompt = new Beat(
            "Like, what's the point?",
            1,
            "...",
            "I don't even know what the point is but I've fucking lost it.",
            5
            );

        story[5].rectPrompt.circReact = false;
        story[5].rectPrompt.circPrompt = new Beat(
            "Like, what's the point?",
            1,
            "I'm sorry...",
            "I don't even know what the point is but I've fucking lost it.",
            5
            );
    }
}
