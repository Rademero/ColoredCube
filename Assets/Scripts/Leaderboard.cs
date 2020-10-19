using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class leaderboard : MonoBehaviour
{
    public List<string> times = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        //This is blank for now
    }

    // Update is called once per frame
    void Update()
    {
        //This is blank for now
    }

    //Load the times into the array for storage
    public void LoadTimes() 
    {
        try
        {
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("Assets/times.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine("Loading times...");      //Debug statement
                    Console.WriteLine(line);                    //Debug statement
                    times.Add(line);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    //Save a new time, as long as it's better than an old one
    public void SaveNewTime(string newTime)
    {
        //Start from the front of the list and compare times using the TimeSpan class
        foreach(string time in times){ 
            //If we find the right place to put the time, insert it, drop the last element, and break the loop
            if(TimeSpan.ParseExact(time, @"mm\:ss", null) > TimeSpan.ParseExact(newTime, @"mm\:ss", null))
            {
                times.Insert(times.IndexOf(time), newTime);
                times.RemoveAt(times.Count - 1);
                break;
            }
        }

        //This is ugly but it's the best way to do this with a List structure to ensure no extra lines are added
        String content = times.ElementAt(0) + "\n" + times.ElementAt(1) + "\n" + times.ElementAt(2) + "\n" + times.ElementAt(3) + "\n" + times.ElementAt(4);
        times.Clear();

        //Write the text to the file!
        System.IO.File.WriteAllText("Assets/times.txt", content);
    }
}
