using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script for every button in the game's user interface
public class Button : MonoBehaviour
{
    //Method for loading the game's main level
    public void StartGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single); //Loads the third Scene (Main Level) in Build Settings
    }

    //Method for opening the options menu
    public void LoadOptions()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single); //Loads the second Scene (Options Menu) in Build Settings
    }

    //Method for loading the game's credits roll
    public void ShowCredits()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single); //Loads the fourth Scene (Credits) in Build Settings 
    }

    //Method for closing the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Method for going back to the title screen from the options menu
    public void BackToTitleScreen()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single); //Loads the first Scene (Title Screen) in Build Settings
    }
}
