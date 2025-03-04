using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        PauseScript p = GetComponent<PauseScript>();

        if (p != null) 
        {
            p.PauseEvent += TogglePauseMenuUI;
            p.ResumeEvent += TogglePauseMenuUI;
        }
    }

    void TogglePauseMenuUI() 
    {
        if (pauseUI.activeInHierarchy) 
        {
            pauseUI.SetActive(false);
        } 
        else 
        {
            pauseUI.SetActive(true);
        }
    }

}
