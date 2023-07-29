using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    private int levelToLoad;

    private static readonly int MAINMENU = 0;

    public void FadeToNextLevel()
    {
        //Loads Next Level in the Build Queue
        int bitsh = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log(bitsh);
        FadeToLevel(bitsh);
    }

    public void FadeToLevel(int levelIndex)
    {
        Debug.Log(levelIndex);
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        //Loads scene when Fade Animation is completed
        //Debug.Log(levelToLoad);
        SceneManager.LoadScene(1);
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