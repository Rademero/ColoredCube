using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    Text text;
    float time;
    bool playing;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        playing = true; //THIS IS FOR DEMONSTRATION ONLY
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            time += Time.deltaTime;

            //Do math and get the proper strings
            string minutes = Mathf.Floor(((time % 3600) / 60)).ToString("00"); //Math to make minutes work
            string seconds = (time % 60).ToString("00");

            text.text = minutes + ":" + seconds;
        }
    }

    //Call this to start the timer
    public void Play() 
    {
        playing = true;
    }

    //Call this to stop the timer
    public void Stop()
    {
        playing = false;
    }

    //Call this to reset the timer
    public void Reset()
    {
        time = 0;
    }
}
