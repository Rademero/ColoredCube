using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//Script for handling menu behavior
//Includes both Main Menu and Pause Menu functionality

public class MenuButtonScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject[] pauseObjects;
    public Timer timer;

    void Start() {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPaused");
        HidePaused();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowPaused();
            }
            else if (Time.timeScale == 0) {
                Time.timeScale = 1;
                HidePaused();
            }
        }
    }

    //Load the scene containing Timer functionality (only one currently implemented)
    public void TimedButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Model");
    }

    //Load the scene without Timer or Tutorial functionality
    public void PracticeButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PracticeMode");
    }

    //Load the scene with Tutorial functionality
    public void TutorialButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TutorialMode");
    }

    //Terminate the game
    public void QuitButton() {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;    //This line quits the editor, and is only here for testing purposes.
    }

    public void ResumeButton() {
        Time.timeScale = 1;
        HidePaused();
    }

    public void RestartButton() { 
        //Unimplemented
    }

    public void ToMainMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    //Hides the objects that should only show on pause
    public void HidePaused() {
        foreach (GameObject g in pauseObjects){
            g.SetActive(false);
        }
    }

    public void ShowPaused() {
        foreach (GameObject g in pauseObjects){
            g.SetActive(true);
        }
    }
    
}
