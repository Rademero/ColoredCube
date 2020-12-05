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
    const int NUM_TIPS = 9; //Tracks how many tips we have implemented, for random number generation.

    // Start is called before the first frame update
    void Start()
    {
        //Replace the junk "Lorem Ipsum" text from the editor with an actual message.
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

        switch (random)
        {
            case 1:
                return "The Rubik's Cube was originally called \"The Magic Cube\".";
            case 2:
                return "The Rubik's Cube was created in 1974.";
            case 3:
                return "The center piece is the piece in the middle of each side; it's a good idea to solve only one side first.";
            case 4:
                return "Corner pieces are the pieces diagonal to the center piece.";
            case 5:
                return "The edge pieces are the pieces where two visible colors meet.";
            case 6:
                return "A good way to start is solving the edge pieces first.";
            case 7:
                return "Start by solving the edge pieces to match the center of a specific side, which will result in a plus sign or cross.";
            case 8:
                return "Try to solve multiple edges of a side at once.";
            case 9:
                return "Arrange the remaining colors if you've solved an edge.";
            default:
                return "You generated a value outside the range of tips. That isn't supposed to happen. The number you generated was " + random + " and NUM_TIPS is " + NUM_TIPS;
        }
    }
}
