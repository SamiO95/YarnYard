using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public delegate void PauseDelegate();
    public event PauseDelegate PauseEvent;
    public delegate void ResumeDelegate();
    public event ResumeDelegate ResumeEvent;
    public GameObject gameOverMenu;

    private void Start()
    {
        PauseEvent += PauseGame;
        ResumeEvent += ResumeGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOverMenu.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 0)
                {
                    ResumeEvent?.Invoke();
                }
                else
                {
                    PauseEvent?.Invoke();
                }
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
