using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private static int levelToLoad;

    private static readonly int MAINMENU = 0;

    public void FadeToNextLevel()
    {
        //Loads Next Level in the Build Queue
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        Debug.Log("Fadeout Started");
        animator.SetTrigger("FadeOut");
        //Debug.Log("GraveFadeout Started");
        //animator.SetTrigger("GraveFadeOut");
    }

    public void OnFadeComplete()
    {
        //Loads scene when Fade Animation is completed
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadMainMenu()
    {
        //Loads Main Menu Scene
        FadeToLevel(MAINMENU);
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