using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonScript : MonoBehaviour
{
    public GameObject MainMenu;

    //Load the scene containing Timer functionality (only one currently implemented)
    public void TimedButton() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Model");
    }

    //Load the scene without Timer or Tutorial functionality
    public void PracticeButton() {
        print("This scene is not yet implemented.");
    }

    //Load the scene with Tutorial functionality
    public void TutorialButton() {
        print("This scene is not yet implemented.");
    }

    //Terminate the game
    public void QuitButton() {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;    //This line quits the editor, and is only here for testing purposes.
    }
}
