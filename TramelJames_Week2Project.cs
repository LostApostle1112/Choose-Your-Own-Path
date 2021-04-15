using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TramelJames_Week2Project : MonoBehaviour
{
    Text screen;
  
    Page[] book = new Page[24];

   

        
   
    

    [SerializeField]
    string prevHeading;

    [SerializeField]
    string currHeading;

    [SerializeField]
    string nextHeading = "welcome";

    [SerializeField]
    bool bHasKey;
    
    [SerializeField]
    bool bDoorLocked = true;

    

    // Start is called before the first frame update
    void Start()
    {
        

        ResetGame();

        GameObject go = GameObject.Find("MainText");

        if (go)
        {
            screen = go.GetComponent<Text>();

            if (!screen)
            {
                Debug.LogError("Text component was not found on MainText");
            }
        }
        else
        {
            Debug.LogError("Main text not found!");
        }
        //screen.text = "hello world";

        BindBook();
        
    }


    // Update is called once per frame
    void Update()
    {
        
        HandleInput();
        RenderStory();
        if (currHeading == "pour" || prevHeading == "pour")
        {
            bHasKey = true;
            bDoorLocked = false;
        }
    }
    
    void BindBook()
    {
       

        book = new Page[24]

        /* titles are bold and italicized with commands printed in orange. Game Over lose state red. GameOver win state green*/
        {
            /*I attempted to get the program to keep track and step back through each decision but that failed miserably*/
           book[0] = 
            new Page("welcome","<b><i>( welcome to desert escape )</i></b>\npress <color=orange>'c'</color> to continue to 'desert escape'.\npress <color=orange>'q'</color> at anytime to quit.[well, most any time.]"),
           book[1] =
               new Page("the beginning","<b><i>( your vacation )</i></b>\nyou have been backpacking through egypt soaking in the sights. everything was going well until this evenings adventure had you struggling with finding a room for the night. the receptionist at the last place said, 'all the reputable establishments are full with it being peak tourism season.' giving you an old buisness card he continued.'go to this address, it's nothing fancy but they have a bed and a shower. if you get there in time'. well looks like you only have two options. <color=orange>'o'</color>ne, continue to the address on the card or just <color=orange>'q'</color>uit while you're ahead and sleep in the desert"),
//new branch 1
            book[2] =
               new Page("old adobe inn","<b><i>( you arrive )</i></b>\nafter walking, for what seemed like hours, you arrive at a dimly lit adobe inn. although you get an erie feeling from this place the thought of a soft bed and hot shower are too enticing to pass up. besides, there is a wonderful aroma wafting through the foyer as you enter. handing the buisness card to the receptionist; the odd, short man giggles a little as he shows you to your room. 'the kitchen has <color=orange>'d'</color>inner prepped if you would like me to have some brought up sir', the odd, little man adds as he opens the door to your room.' or , if you'd like to <color=orange>'r'</color>est just place the 'do not disturb' sign on the outside and we'll leave you be.' or press <color=orange>'x'</color> to return to the previous step. "),
//new branch 2
            book[3]=
               new Page ("dinner","<b><i>( dinner arrives )</i></b>\ndinner arrives just as you finish your shower. mmmm, brazed beef with rice and veggies. it tastes as good as it smells. as you finish your meal you start to plan the next day's adventure.'maybe the <color=orange>'s'</color>phinx tomorrow, or maybe the pyramids.' You snuggle into your comfy bed with the final thought, 'maybe i should <color=orange>'q'</color>uit and go home or press <color=orange>'x'</color> to return to the previous step."),
            book[4]=
               new Page("wake up","<b><i>( wake up )</i></b>\nyou awaken in a sweltering room that smells of dust and dry rot. to your left, you see a woven basket, about three feet in front you see a deep steel bowl filled with what looks like milk, and 10 feet beyond that is a heavy iron door you assume is locked. will you check the <color=orange>‘w’</color>oven basket, <color=orange>‘b’</color>owl, or <color=orange>‘d’</color>oor?"),
// above is the beginning...this is finished
// below is main story body

// basket to have new branch = reach in basket && door && bowl 
            book[5]=
               new Page("basket","<b><i>( basket )</i></b>\nyou walk over to examine the woven basket, which stands almost 3 feet tall. you see that the lid on the basket has a handle, but when you try to pull up a strange noise issues from the basket, and the lid seems to be tied down. you find ties on four sides of the basket holding the lid on. <color=orange>'o'</color> the basket, to check it's contents, check the <color=orange>'d'</color>oor, or press <color=orange>'x'</color> to return to the previous step."),
             book[6]=
               // lose state ..new branch...alt. ending
               new Page("snake bit","<b><i>(Snake!)</i></b>\n as you open the lid a sharp pain runs through your abdomen. looking down you see a viper with it's fangs deep in your chest...fading...slowly you fall to the floor. the last sight you beheld as you lie on the ground, panting for your last breath was a picture of your family tied up in a desert tomb. <color=red>You died!! press 'c' to continue</color>"),
             book[7]=
               new Page("door","<b><i>( door )</i></b>\nwhile you think it should be easy enough to waltz through the iron door. when you come upon it, you realize it is much heavier than originally thought. you put all your weight into it to find it only groans and will not budge.it seems you will need a key to unlock the door before it moves anymore. press <color=orange>‘x’</color> to return to the previous step."),

             book[8]=
               new Page("bowl of milk", "<b><i>( bowl of milk)</i></b>\nyou look at the bowl of creamy liquid before you, unsure of its contents. you tap the bowl with your foot and see that the liquid moves with the same viscosity as milk would. you are quite parched, do you <color=orange>‘p’</color> up the bowl or press <color=orange>‘x’</color> to return to the previous step."),

             book[9]=
               new Page("pick up", "<b><i>( pick up )</i></b>\nyou pick up the bowl and bring it closer to sniff the contents. the smell of the liquid is mild, though there is a twinge of something odd to it that you cannot place your finger on.you slosh the liquid a bit and notice something shifting at the bottom of the bowl. do you <color=orange>‘p’</color>our out the contents or <color=orange>‘d’</color>rink the liquid? or press <color=orange>'x'</color> to return to the previous step"),
             book[10]=
               //was the win state now path change
               new Page("pour", "<b><i>( pour )</i></b>\nyou pour out all the contents onto the dusty floor, including what seems to be some maggots and a wrought iron key. one that looks to fit in the keyhole of the heavy door. as thoughts of leaving this nightmare start to creep in, you hear a strange sound coming from the woven basket. does curiosity have you inspect the <color=orange>'w'</color>oven basket? you do have a key. Maybe you can use the key to unlatch the <color=orange>'d'</color>oor and budge it enough to escape? or press <color=orange>'x'</color> to return to the previous step."),
             book[11]=
               new Page ("iron door","<b><i>(iron door)</i></b>\n upon further inspection, there seems to be hieroglyphs carved into the door. Unsure of what the symbols mean, your only priority is escape. the key works!! the door slowly swings open to reveal a dimly lit hall of sandstone. ceilings tower overhead held in place by statues of egyptian gods. the smell of the humid desert wofts about in this cavern. considering how cool it is you can only assume you're underground. in the direction of the cool humid breeze, down a dark path, you hear an strange murmuring, shall we <color=orange>'i'</color>nvestigate? There is another one, to the right, do you want to <color=orange>'t'</color>ake that path? i think i see light down there. or we can check out that <color=orange>'w'</color>oven basket again? if these don't sound good press <color=orange>'x'</color> to go back to the previous step."),
             book[12]=
                //lose state
               new Page("drink", "<b><i>( drink )</i></b>\nyou decide your thirst could help to kill two birds with one stone and begin to drink the liquid. the liquid isn’t milk at all and has a severe acrid taste, you swallow some more anyway, feeling chunks of items floating on your tongue. you spit out the bits and upon further inspection see they are wriggling. you toss the bowl away from you as you feel the need to wretch.standing up you see a key landing next to the tossed bowl and as you go to reach for it, you fall forward, mind hazing into unconsciousness.<color=red> you lose! press 'c' to continue </color>"),
             book[13]=
               new Page ("quit","<b><i>( are you sure? )</i></b>\nyou don't really want to quit do you? <color=orange>'y'</color> or <color=orange>'n'</color>"),
             book[14]=
               new Page("play again","<b><i>( play again? )</i></b>\nthank you for playing 'desert escape'. would you like to play again? press <color=orange>'y'</color> or <color=orange>'n'</color>"),
             book[15]=
               new Page("no 1","<b><i>( Are you sure? )</i></b>\n we'd really like you to stick around. it'll be fun, what do you say?<color=orange>'y' </color> or <color=orange>'n'</color> "),
             book[16]=
               new Page("no 2","<b><i>(C'mon)</i></b>\ni might even guide you through this time. have you found the lit path. give it another go. <color=orange>'y'</color> or <color=orange>'n'</color>"),
             book[17]=
               new Page("no 3","<b><i>(It won't hurt)</i></b>\nwell...maybe a little, <color=orange>'y'</color> or <color=orange>'n'</color>"),
             book[18]=
               new Page("thank you","<b><i>(i get it..)</i></b>\nit's too much for you i know. thank you for playing desert escape...till we meet again. press <color=orange>'t'</color> to return to the title screen."),

           

        // everything above here works and is done
             book[19]=
        //win state "investigate"
                new Page("investigate", "<b><i>(You continue tword the sounds)</i></b>\n the murmuring gets louder as you stumble through the dark. hoping for signs of help you scream out, 'hello, is anyone there?' the only sound to come back was a booming echo of your voice and then a slow rumble. pebbles start to fall from the ceiling as the rumble gets louder...oh no, a cave in! you black out as a boulder comes crushing down on the top of your head. 'over here, we've got something!' you start to come to as you're being dragged from the rubble. the paramedics strap you to the gurney and bombard you with questions. the only words from your mouth, 'wake me up when it's over.' <color=lime>you win!!</color> press <color=orange>'c'</color> to continue."),
             book[20]=
                new Page("take the path", "<b><i>(the glow)</i></b>\nnot wanting to find out what could be lurking in the dark, you take the 'safe' option and follow the glow down the path to the right. the glow starts to get brighter as you walk, but the path leads further down. you reach a circular room with two doors, one on either side. the light that drew you in came from a lit scone on the wall, beside the door on the right. though that path is <color=orange>'d'</color>imly lit you're considering checking further. however, the path on the <color=orange>'r'</color>ight looks to have the glow of daylight at the end of it. could that be possible, we are deep underground? press <color=orange>'x'</color> to go back one step. "),
             book[21]=
                new Page ("the tomb","<b><i>( sandstone stairs )</i></b>\nyou make your way down this hall ending at a spiral stairwell. you start to question if it is a good idea to go further into this nightmare. slowly, you start considering e<color=orange>'x'</color>iting this hall and going back where you came. what are you're options at that point? one, following an erie sound or two, checking out that other light? maybe we'll just continue <color=orange>'d'</color>own the stairs? "),
             book[22]=
                //lose state :trap
                new Page ("epicenter","<b><i>( daylight? )</i></b>\nas you proceed further the light gets brighter. it is daylight! in the excitement of finally escaping from this horrid place you pick up speed. finally reaching the day lit room, you notice it looks as if you're inside a pyramid. this hall is held up by four giant statues of anubis and horus. in aww at the splendor of the statues, you momentarilly forget about escape. eyes to the ceiling, you stumble about until you feel your foot sink into the stone as the pressure plate below it gave under your weight. as booming rumble fills the room, you notice panels in the ceiling open up. thousands of scarabs, spiders and scorpions issue fourth as nightmarish rain from the ceiling. you run back up the path you came from but not without being bitten and stung by a few of the horrid pests. as you reach the circular room you fall to your knees, you can't feel your legs, it's getting harder to breath. right before you fall into death's embrace, you see someone. the odd, little man from the old adobe inn, giggling maniacally,'this body will do well.' his sadistic laughter to echo throgh your spirit for all eternity. <color=red>you died! press 'c' to continue.</color> "),
             book[23]=
                //win state
                new Page("spiral stairs","<b><i>( you dare! )</i></b>\n you make your way down the dimly lit stairwell. it gets darker and darker as you go further down. thoughts tumble through your head. was this a good idea? will i ever be rescued? doubt and fear creep in where hope and faith once lived. your mouth is dry, your stomach growls. suddenly, behind you, you hear a familure creepy giggling. 'i am sure it's this way, they couldn't have gone far.' hurredly you pick up your pace, quickly finding the base of the stairs. the sight before you,in this dim room, is that of every old 'creature feature'. mummies line the walls, some in sarcophagi others without. as the creepy voice gets closer you stammer to find something to protect yourself with. you pull the scone from the wall to direct the light in your search. suddenly the floor panel you were standing on gave way sending you sliding down a hole. fear grips your sole at the not knowing of what lies at the end of this horror slide. scraping your arms and legs along the stone, the pain starts to become more than you can bear. then, just as you see light, a searing burn rushes through your body as your flung out of the side of the temple and in the river. bleeding, wet and exausted, you make it to the shore. tourists stand around taking pictures and gawking at you for what they just witnessed. you survived,<color=lime> you won!</color> was it luck? who knows. press <color=orange>'c'</color> to continue ")
        };
    }

    void RenderStory()
    {
        
        
        if (!string.IsNullOrEmpty(nextHeading))
        {
            for (int i = 0; i < book.Length; i++)
                
            {
           
                if (nextHeading == book[i].Heading)
                {
                    
                    prevHeading = currHeading;
                    currHeading = nextHeading;
                    nextHeading = "";
                    
                    screen.text = book[i].Body;
                    Debug.Log(book[i].Body);
                   
                    return;
                    
                }
            }
            Debug.LogWarning("Heading not found: \"" + nextHeading + "\"");
        }
        

    }
    void ResetGame()
    {
        bHasKey = false;
        bDoorLocked = true;

       
    }
    void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (currHeading == "wake up" )
            {
                nextHeading = "bowl of milk";
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currHeading == "basket"|| currHeading == "bowl of milk"|| currHeading == "wake up"|| currHeading == "pour")
            {
                if (bHasKey == true && bDoorLocked == false)
                {
                    nextHeading = "iron door";
                }
                else
                {
                    nextHeading = "door";
                }
            }
            if (currHeading == "pick up")
            {
                nextHeading = "drink";
            }
            else if (currHeading == "old adobe inn")
            {
                nextHeading = "dinner";
            }
            else if (currHeading == "take the path")
            {
                nextHeading = "the tomb";
            }
            else if (currHeading == "the tomb")
            {
                nextHeading = "spiral stairs";
            }
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (currHeading == "play again" || currHeading == "no 1" || currHeading == "no 2" || currHeading == "no 3")
            {
                nextHeading = "welcome";
                ResetGame();
            }
            else if (currHeading == "quit")
            {
                nextHeading = "no 1";
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currHeading == "wake up" || currHeading == "pour" || currHeading == "iron door")
            {
                nextHeading = "basket";
            }
            
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (currHeading == "bowl of milk")
            {
                nextHeading = "pick up";
            }
            else if (currHeading == "pick up")
            {
                nextHeading = "pour";
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (currHeading == "welcome")
            {
                nextHeading = "the beginning";
            }

            else if (currHeading == "drink" || currHeading == "epicenter" || currHeading == "spiral stairs")
            {
                nextHeading = "play again";
            }
            else if (currHeading == "snake bit")
            {
                nextHeading = "play again";
            }
            else if (currHeading == "investigate")
            {
                nextHeading = "play again";
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (currHeading == "quit")
            {
                nextHeading = "play again";
            }
            else if (currHeading == "play again")
            {
                nextHeading = "no 1";
            }
            else if (currHeading == "no 1")
            {
                nextHeading = "no 2";
            }
            else if (currHeading == "no 2")
            {
                nextHeading = "no 3";
            }
            else if (currHeading == "no 3")
            {
                nextHeading = "thank you";
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            
                if (currHeading == "bowl of milk" || currHeading == "door" || currHeading == "pick up" || currHeading == "iron door" || currHeading == "pour" || currHeading == "investigate" || currHeading == "old adobe inn" || currHeading == "take the path" || currHeading == "the tomb")
                {
                    nextHeading = prevHeading;

                }
                else if (currHeading == "basket")
                {
                    nextHeading = "wake up";
                }

            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currHeading == "the beginning")
            {
                nextHeading = "wake up";
            }
            else if (currHeading == "wake up" || currHeading == "old adobe inn" || currHeading == "dinner" || currHeading == "basket" || currHeading == "door" || currHeading == "bowl of milk" || currHeading == "pick up" || currHeading == "iron door" || currHeading == "investigate" || currHeading == "take the path" || currHeading == "the tomb" || currHeading == "welcome")
            {
                nextHeading = "quit";
            }
           
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (currHeading == "the beginning")
            {
                nextHeading = "old adobe inn";
            }
            else if (currHeading == "basket")
            {
                nextHeading = "snake bit";
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currHeading == "old adobe inn")
            {
                nextHeading = "wake up";
            }
            else if (currHeading == "take the path")
            {
                nextHeading = "epicenter";
            }
        }
        if (Input.GetKeyDown(KeyCode.S)) //sphinx
        {
            nextHeading = "wake up";
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (currHeading == "iron door")
            {
                nextHeading = "investigate";
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (currHeading == "iron door")
            {
                nextHeading = "take the path";
            }
            else if (currHeading == "thank you")
            {
                nextHeading = "welcome";
            }
        }
    }
}