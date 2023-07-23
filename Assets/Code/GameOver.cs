using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<PlayerCharacter>().PlayerDeathEvent += YouDied;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverMenu.activeInHierarchy || pauseMenu.activeInHierarchy) 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //Sets the Game Over UI to active when the Player dies
    public void YouDied()
    {
        gameOverMenu.SetActive(true);
    }
}
