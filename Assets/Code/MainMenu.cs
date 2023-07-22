using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        //Loads first level after Main Menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Retry()
    {
        //Restarts current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        //Exits the application
        Application.Quit();
    }

}