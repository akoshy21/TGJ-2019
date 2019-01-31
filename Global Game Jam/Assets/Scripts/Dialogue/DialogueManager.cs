using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Beat[] story;
    public int response;

    public Image fadeOut;
    public bool fade;
    public bool finalFade;

    public AudioClip[] clips = new AudioClip[33];

    public AudioSource source;

    public int beatIndex = 0;
    public Beat previousBeat;
    public Beat currentBeat;
    public bool start = false;

    public GameObject player;

    public Text prompt;
    public Image promptBubble;

    public Image thought;

    public Image rectButton;
    public Text rbText;

    public Image circButton;
    public Text cbText;

    public Image triButton;
    public Text tbText;

    public Image xButton;
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
        CheckStart();
        StartCoroutine(TimedStart());
        if (start) {
            audioPlayer();
            StartCoroutine(CheckInput());
        }

        if (fade)
        {
            FadeTimer();
            FadeOutFunc();
        }
        else {
            FadeInFunc();
        }

        StartCoroutine(End());

        Escape();
    }

    void Escape()
    {
        Debug.Log("ESC");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Restart()
    {
        Debug.Log("RESTART");
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("KevinScene");
        }
    }

    void CheckStart()
    {
        if (!start)
        {
            if (player.GetComponent<Player_Controller>().curLives == 1)
            {
                start = true;
                ActivateButtons(true);
                thought.gameObject.SetActive(true);
                promptBubble.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator FadeTimer()
    {
        yield return new WaitForSeconds(3);
        finalFade = true;
    }

    void FadeOutFunc()
    {
        if (finalFade)
        {
            Debug.Log("FadeOut");
            for (int i = 0; i < 255; i++)
            {
                fadeOut.color += Time.deltaTime * 3 * new Color(0, 0, 0, 0.1f);
            }
        }
    }

    void FadeInFunc()
    {
        if (!finalFade)
        {
            Debug.Log("FadeIn");

            fadeOut.color -= Time.deltaTime * 3 * new Color(0, 0, 0, 0.1f);
        }
    }

    IEnumerator End()
    {
        if (beatIndex == 12)
        {
            start = false;
            yield return new WaitForSeconds(10);
            thought.gameObject.SetActive(false);
            promptBubble.gameObject.SetActive(false);
        }
    }

    IEnumerator TimedStart()
    {
        Debug.Log("Started timer");
        yield return new WaitForSeconds(35);
        if (!start)
        {
            start = true;
            ActivateButtons(true);
            thought.gameObject.SetActive(true);
            promptBubble.gameObject.SetActive(true);
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

    void audioPlayer() {
        if (currentBeat.clip != null)
        {
            if (source.clip != currentBeat.clip)
            {
                source.clip = currentBeat.clip;
                source.Play();
            }
        }
    }

    IEnumerator CheckInput()
    {
        if (allowInputRect)
        {
            if (Input.GetButtonDown("Triangle") || Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (beatIndex == 11 && currentBeat.prompt.Equals(story[11].rectPrompt))
                {
                    fade = true;
                }

                if (!currentBeat.rectReact)
                {
                    ActivateButtons(false);
                    yield return new WaitForSeconds(1.5f);
                    MoveBeat(currentBeat.rectPrompt);
                    ActivateButtons(true);
                }
                else
                {
                    beatIndex++;

                    ActivateButtons(false);
                    yield return new WaitForSeconds(1);
                    prompt.text = currentBeat.rectReaction;
                    Debug.Log(currentBeat.rectReaction);
                    yield return new WaitForSeconds(currentBeat.rDelay);
                    thought.gameObject.SetActive(false);
                    promptBubble.gameObject.SetActive(false);
                    yield return new WaitForSeconds(currentBeat.delay);
                    thought.gameObject.SetActive(true);
                    promptBubble.gameObject.SetActive(true);
                    MoveBeat(story[beatIndex]);
                    ActivateButtons(true);
                }
            }
        }
        if (allowInputCirc)
        {
            if (Input.GetButtonDown("Square") || Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (!currentBeat.circReact)
                {
                    ActivateButtons(false);
                    yield return new WaitForSeconds(1.5f);
                    MoveBeat(currentBeat.circPrompt);
                    ActivateButtons(true);
                }
                else
                {
                    beatIndex++;

                    ActivateButtons(false);
                    yield return new WaitForSeconds(1);
                    prompt.text = currentBeat.circReaction;
                    yield return new WaitForSeconds(currentBeat.rDelay);
                    thought.gameObject.SetActive(false);
                    promptBubble.gameObject.SetActive(false);
                    yield return new WaitForSeconds(currentBeat.delay);
                    thought.gameObject.SetActive(true);
                    promptBubble.gameObject.SetActive(true);
                    MoveBeat(story[beatIndex]);
                    ActivateButtons(true);
                }
            }
        }
        if (allowInputTri)
        {
            if (Input.GetButtonDown("Circle") || Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (beatIndex == 0)
                {
                    asked711 = true;
                }

                if (!currentBeat.triReact)
                {
                    ActivateButtons(false);
                    yield return new WaitForSeconds(1.5f);
                    MoveBeat(currentBeat.triPrompt);
                    ActivateButtons(true);
                }
                else
                {
                    beatIndex++;


                    ActivateButtons(false);
                    yield return new WaitForSeconds(1);
                    prompt.text = currentBeat.triReaction;
                    yield return new WaitForSeconds(currentBeat.rDelay);
                    thought.gameObject.SetActive(false);
                    promptBubble.gameObject.SetActive(false);
                    yield return new WaitForSeconds(currentBeat.delay);
                    thought.gameObject.SetActive(true);
                    promptBubble.gameObject.SetActive(true);
                    MoveBeat(story[beatIndex]);
                    ActivateButtons(true);
                }
            }
        }
        if (allowInputX)
        {
            if (Input.GetButtonDown("Cross") || Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (!currentBeat.xReact)
                {
                    ActivateButtons(false);
                    yield return new WaitForSeconds(1.5f);
                    MoveBeat(currentBeat.xPrompt);
                    ActivateButtons(true);
                }
                else
                {
                    beatIndex++;

                    ActivateButtons(false);
                    yield return new WaitForSeconds(1);
                    prompt.text = currentBeat.xReaction;
                    yield return new WaitForSeconds(currentBeat.rDelay);
                    thought.gameObject.SetActive(false);
                    promptBubble.gameObject.SetActive(false);
                    yield return new WaitForSeconds(currentBeat.delay);
                    thought.gameObject.SetActive(true);
                    promptBubble.gameObject.SetActive(true);
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
        story = new Beat[12];

        BeatZero();
        BeatOne();
        BeatTwo();
        BeatThree();
        BeatFour();
        BeatFive();
        BeatSix();
        BeatSeven();
        BeatEight();
        BeatNine();
        BeatTen();
        BeatEleven();

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
            "...",
            "Gimme like ten minutes.",
            "I’ll starve by then. Do you want that blood on your hands?",
            4
            );
        story[0].rDelay = 2;
        story[0].clip = clips[23]; // You hungry?

        story[0].triReact = false;
        story[0].triPrompt = new Beat(
            "We should go to 7/11.",
            2,
            "We go there a lot.",
            "Yeah: we’re garbage people!",
            "I’m down, gimme one sec.",
            "Uhuh",
            5
            );

        story[0].triPrompt.clip = clips[1];

    }

    void BeatOne()
    {
        story[1] = new Beat(
            "Can we go to 7/11?",
            3,
            "Sure.",
            "Awesome, let me grab some stuff.",
            "I'd rather not.",
            "Oh...Guess I’ll go alone.",
            "Let me finish this first.",
            "Okay.",
            "You just asked me like, 4 seconds ago.",
            "I’m still hungry.",
            1.5f
            );

        story[1].clip = clips[16];

        story[1].rDelay = 2;

    }

    void BeatTwo()
    {
        story[2] = new Beat("Damn it. I don’t have any cash.",
            2,
            "So no on the taquitos?",
            "...",
            "Lol same.",
            "...",
            14
            );

        story[2].rDelay = 2;
        story[2].clip = clips[3];

        story[2].rectReact = false;
        story[2].rectPrompt = new Beat(
            "*Sigh* Do you have any cash?",
            1,
            "Nope",
            "...",
            14
            );
        story[2].rectPrompt.clip = clips[2];

        story[2].rectPrompt.rectReact = false;
        story[2].rectPrompt.rectPrompt = new Beat(
            "Guess I’ll die, then!",
            1,
            "*Gargle sympathetically*",
            "You're a freak!",
            14
            );
        story[2].rectPrompt.rectPrompt.clip = clips[17];

        story[2].circReact = false;
        story[2].circPrompt = new Beat(
            "*Groans*",
            2,
            "*Gargle sympathetically*",
            "You’re a freak!",
            "...",
            "...",
            14
            );
        story[2].circPrompt.clip = clips[17];

    }

    void BeatThree()
    {
        story[3] = new Beat(
            "How’s the game going?",
            3,
            "Great",
            "Cool. Cool...",
            "*Sarcastic* Great.",
            "...",
            "Surprisingly hard?",
            "...",
            .5f
            );

        story[3].clip = clips[6];

        story[3].circReact = false;
        story[3].circPrompt = new Beat(
            "Yeah that’s cause you’re not a real gamer.",
            2,
            "I’m so sorry father.",
            "*Croaks*",
            "YOU’RE not a real gamer!",
            "...",
            16
            );
        story[3].circPrompt.clip = clips[18];

        story[3].triReact = false;
        story[3].triPrompt = new Beat(
            "*Looks Expectantly*",
            2,
            "I think this game’s just bad.",
            "Sure you’re not just bad at it?",
            "I dunno. I should try dying less, right?",
            "*Nods* Video games.",
            16
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
            "...",
            "Welp.",
            "Welp indeed.",
            "...",
            "...",
            6
            );

        story[4].clip = clips[19];

        story[4].circReact = false;
        story[4].circPrompt = new Beat(
                "...",
                2,
                "Are you okay?",
                "Yeah...Maybe. I don't know.",
                "...",
                "...",
                6
            );
    }

    void BeatFive()
    {
        story[5] = new Beat(
                "...",
                2,
                "What're you gonna do?",
                "...",
                "Do you know why?",
                "That's the worst part.",
                4
            );

        story[5].rectReact = false;
        story[5].rectPrompt = new Beat(
                "Ya know what the worst part is?",
                2,
                "...What?",
                "...",
                "...",
                "...",
                1
            );
        story[5].rectPrompt.clip = clips[24];

        story[5].rectPrompt.rectReact = false;
        story[5].rectPrompt.rectPrompt = new Beat(
            "Like, what's the point?",
            1,
            "...",
            "I don't even know what the point is but I've fucking lost it.",
            2
            );
        story[5].rectPrompt.rectPrompt.clip = clips[9];

        story[5].rectPrompt.circReact = false;
        story[5].rectPrompt.circPrompt = new Beat(
            "Like, what's the point?",
            1,
            "I'm sorry...",
            "I don't even know what the point is but I've fucking lost it.",
            2
            );
        story[5].rectPrompt.circPrompt.clip = clips[9];

    }

    void BeatSix()
    {
        story[6] = new Beat(
                "Sometimes, I dunno, I just think she hates me.",
                4,
                "Why?",
                "I dunno, it just feels like she'd be happier if I weren't there. As if talking to me is a chore... or painful, even.",
                "That's - no way.",
                "...",
                "*Sarcastic* Same.",
                "...",
                "Maybe it's just stress.",
                "...",
                4
            );
        story[6].clip = clips[9];

        story[6].circReact = false;
        story[6].circPrompt = new Beat(
            "Yeah? Why not?",
            2,
            "You've been friends forever, right?",
            "Yeah... But friends drift apart... You know.",
            "You guys seem happy.",
            "Yeah, but happy takes work now.",
            6
            );
        story[6].circPrompt.clip = clips[13];

        story[6].triReact = false;
        story[6].triPrompt = new Beat(
            "You did spill hot tea on her.",
            3,
            "It was an accident!",
            "Uhuh...",
            "Ha, yeah I did.",
            "Uhuh.",
            "That was literally 2 years ago.",
            "Well maybe you burned her feelings.",
            3
            );
        story[6].triPrompt.clip = clips[27];

        story[6].xReact = false;
        story[6].xPrompt = new Beat(
            "Can't be man. It was like this even over break.",
            1,
            "Like what?",
            "Desolate.",
            7
            );
        story[6].xPrompt.clip = clips[12];
    }

    void BeatSeven()
    {
        story[7] = new Beat(
            "I'm just lost man.",
            3,
            "Well, what about you?",
            "...",
            "Did something happen?",
            "...",
            "Maybe you need a break.",
            "Alex said if we took a break it wouldn't end.",
            4
            );
        story[7].clip = clips[19];

        story[7].rectReact = false;
        story[7].rectPrompt = new Beat(
            "What about me?",
            1,
            "Do you hate her?",
            "...",
            7
            );
        story[7].rectPrompt.clip = clips[28];

        story[7].circReact = false;
        story[7].circPrompt = new Beat(
            "Nope. I wish something would though.",
            2,
            "Don't talk like that.",
            "Why not? At this point...",
            "It'll be okay, right?",
            "I wish I believed you.",
            3
            );
        story[7].circPrompt.clip = clips[11];
    }

    void BeatEight()
    {
        story[8] = new Beat(
            "What should I do?",
            3,
            "Romantic gesture?",
            "...",
            "I think you know.",
            "...",
            "I'm sorry, I don't know.",
            "...",
            8
            );
        story[8].clip = clips[6];

        story[8].rectReact = false;
        story[8].rectPrompt = new Beat(
            "Hah. Somehow I doubt flowers will be enough.",
            1,
            "What about *lots* of flowers?",
            "*He flashes a faint smile*",
            8
            );
        story[8].rectPrompt.clip = clips[8];

        story[8].circReact = false;
        story[8].circPrompt = new Beat(
            "Yeah.",
            2,
            "I'm sorry man",
            "Me too.",
            "I love you buddy.",
            "...",
            4
            );
        story[8].circPrompt.clip = clips[31];

        story[8].circPrompt.circReact = false;
        story[8].circPrompt.circPrompt = new Beat(
            "Love you too man.",
            1,
            "...",
            "*He flashes a faint smile*",
            8
            );

        story[8].triReact = false;
        story[8].triPrompt = new Beat(
            "It's okay man. I don't either...",
            1,
            "...",
            "Thanks for listening though. It helps",
            8
            );
    }

    void BeatNine()
    {
        story[9] = new Beat(
            "*He's staring off somewhere*",
            3,
            "Hey. It's not your fault.",
            "...",
            "At least we put up with you.",
            "...",
            "Don't get wound up by it.",
            "...",
            1
            );

        story[9].rectReact = false;
        story[9].rectPrompt = new Beat(
            "Isn't it?",
            2,
            "No dumbass.",
            "...",
            "Ain't anyone's faults.",
            "I know...",
            12
            );
        story[9].rectPrompt.clip = clips[6];

        story[9].rectPrompt.rectReact = false;
        story[9].rectPrompt.rectPrompt = new Beat(
            "I don't know man.",
            1,
            "Well I do, you don't have to.",
            "*He laughs*",
            5
            );
        story[9].rectPrompt.clip = clips[9];

        story[9].circReact = false;
        story[9].circPrompt = new Beat(
            "Aw shucks... Thanks 'dad'.",
            2,
            "I hate you, son.",
            "*He beams*",
            "1403's got your back, okay?",
            "I know... Love you guys.",
            5
            );
        story[9].circPrompt.clip = clips[7];

        story[9].triReact = false;
        story[9].triPrompt = new Beat(
            "What if I already am?",
            1,
            "...",
            "...",
            14
            );
        story[9].triPrompt.clip = clips[12];

        story[9].triPrompt.triReact = false;
        story[9].triPrompt.triPrompt = new Beat(
            "...",
            2,
            "Well, whatever happens, I'll be here.",
            "Hah. Of course. You haven't been outside in a fucking year.",
            "Just... don't forget it'll be alright.",
            "I won't.",
            6
            );
    }

    void BeatTen() {
        story[10] = new Beat(
            "*He yawns*",
            3,
            "Wish we had a window.",
            "...",
            "You excited for tomorrow?",
            "...",
            "I'm gonna miss this.",
            "...",
            7
            );
        story[10].clip = clips[29];

        story[10].rectReact = false;
        story[10].rectPrompt = new Beat(
            "Yeah, I like to imagine New York's pretty at night.",
            2,
            "Not as pretty as me.",
            "Everything's prettier than you.",
            "We could drill a hole in the wall?",
            "I'm sure there will be no dire consequences to that decision.",
            8
            );
        story[10].rectPrompt.clip = clips[30];
        
        story[10].circReact = false;
        story[10].circPrompt = new Beat(
            "What's tomorrow?",
            3,
            "The zoo, man!",
            "...",
            "Central Park, remember?",
            "...",
            "Magic prerelease!",
            "...",
            8
            );

        story[10].circPrompt.rectPrompt = new Beat(
            "Oh yeah! Fuck yeah!",
            1,
            "Fuck yeah.",
            "...",
            6
            );
        story[10].circPrompt.rectPrompt.clip = clips[5];

        story[10].circPrompt.circPrompt = new Beat(
            "Oh yeah! Fuck yeah!",
            1,
            "Fuck yeah.",
            "...",
            6
            );
        story[10].circPrompt.circPrompt.clip = clips[5];

        story[10].circPrompt.triPrompt = new Beat(
            "Oh yeah! Fuck yeah!",
            1,
            "Fuck yeah.",
            "...",
            6
            );
        story[10].circPrompt.triPrompt.clip = clips[5];

        story[10].triReact = false;
        story[10].triPrompt = new Beat(
            "We all will. But hey, summer's only 3 months, yeah?",
            1,
            "That's the spirit.",
            "Trying to be optimistic.",
            8
            );
        story[10].triPrompt.clip = clips[26];
    }

    void BeatEleven() {
        story[11] = new Beat(
        "Good god, it's late.",
        2,
        "Is 3:30 really late?",
        "...",
        "Yeah...",
        "...",
        1
        );
        story[11].clip = clips[15];

        story[11].rectReact = false;
        story[11].rectPrompt = new Beat(
            "It is if it's in the fucking morning! I'm going to bed.",
            2,
            "Same, good night man.",
            "...",
            "I'm gonna play a bit more, okay?",
            "...",
            3            
            );

        story[11].rectPrompt.rectPrompt = new Beat(
            "Good night mate!",
            1,
            "Night.",
            "...",
            6
            );
        story[11].rectPrompt.rectPrompt.clip = clips[4];

        story[11].rectPrompt.circPrompt = new Beat(
            "Good night mate!",
            1,
            "Night.",
            "...",
            6
            );
        story[11].rectPrompt.circPrompt.clip = clips[4];
    }
}
