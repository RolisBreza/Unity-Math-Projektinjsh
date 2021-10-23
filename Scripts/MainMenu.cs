using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame() 
    {
        //I could LoadScene("Name") or go for build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //It will go to the next scene in queue
    } 

    public void QuitGame()
    {
        Application.Quit(); //But it won't do anything in unity editor, so just to be safe and know that the function was called, there's a debug line
        Debug.Log("Quit");
    }

   
    //for options, I don't need to do any programming, simply add an action that will set active function

}

//To add scenes to queue go to file-build settings - and then drag them in
//To apply this code to a button, Choose the button and drag this main menu object to an event and find the appropriate function
