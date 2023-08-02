using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<PlayerCharacter>().PlayerDeathEvent += YouDied;
    }

    //Sets the Game Over UI to active when the Player dies
    public void YouDied()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
