using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToTitleScreen()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void SaveVolumeSettings()
    {
        //Nothing here yet
    }
}
