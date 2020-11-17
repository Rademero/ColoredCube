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
    const int NUM_TIPS = 3;

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
                return "Testing, Testing";
            case 2:
                return "Hello there!";
            case 3:
                return "This should be a tip...";
            default:
                return "Something went wrong... the number generated was: " + random;
        }
    }
}
