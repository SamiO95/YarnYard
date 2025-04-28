using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] 
    private Texture2D cursorTexture;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject optionsMenu;

    [SerializeField] 
    private GameObject gameOverMenu;

    [SerializeField]
    private GameObject winMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverMenu.activeInHierarchy || pauseMenu.activeInHierarchy || optionsMenu.activeInHierarchy || winMenu.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
