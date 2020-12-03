using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipScript : MonoBehaviour
{
    Text text;
    float time;
    int seconds = 0;
    int timeAtChange = 0;

    const int DELAY = 20;   //Determines how many seconds between a tip change.
    const int NUM_TIPS = 9;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "This box will display helpful tips on how to solve the cube! First, check out the Controls menu to your right and start messing around!";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        seconds = (int)(time + 0.5);

        //Change the tip if it has been <DELAY> seconds
        if (seconds != timeAtChange && seconds % DELAY == 0) {
            text.text = getTip();
            timeAtChange = seconds;     //This is a safeguard to ensure the tip is only changed once, as Update (and the seconds % 20 check) executes every frame instead of every second
        }

    }

    public string getTip() {
        int random = Random.Range(1, NUM_TIPS + 1);     //Generates between min (inclusive) and max (exclusive), hence the + 1

        //Austin,
        //Make more cases as you see fit, and replace the current cases with your general-purpose tips.
        //All other code is handled, so you don't need to worry about the Lorem Ipsum in the editor or
        //the default text. Please leave the default case, and change NUM_TIPS as you add more tips.
        //Remove this comment once you're done. - Patrick

        switch (random)
        {
            case 1:
                return "The Rubik's Cube was originally called \"the magic cube\" ";
            case 2:
                return "The Rubik's Cube was created in 1974";
            case 3:
                return "The center piece is the piece in the middle of each side; it's a good idea to solve only one side first";
            case 4:
                return "Corner pieces are the pieces diagonal to the center piece";
            case 5:
                return "The edge pieces are the pieces connected to the center";
            case 6:
                return "A good way to start is solving the edge pieces first";
            case 7:
                return "Solving edge pieces allow you to get a cross (usually referred to as the white cross)";
            case 8:
                return "Solve multiple edges at once";
            case 9:
                return "Arrange the remaining colors if you've solved an edge";
            default:
                return "You generated a value outside the range of tips. That isn't supposed to happen. The number you generated was " + random + "and NUM_TIPS is " + NUM_TIPS;
        }
    }
}
