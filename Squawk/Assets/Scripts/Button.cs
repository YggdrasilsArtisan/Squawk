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
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    //Method for opening the options menu
    public void LoadOptions()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    //Method for loading the game's credits roll
    public void ShowCredits()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    //Method for closing the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Method for going back to the title screen from the options menu
    public void BackToTitleScreen()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    //Method for saving the player's volume settings for music and sound effects
    public void SaveVolumeSettings()
    {
        //Nothing here yet
    }
}
