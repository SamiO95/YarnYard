using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{

    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private int timerIndex;

    private float startTime;

    [SerializeField]
    private GameObject winMenu;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        timerText.text = minutes + ":" + seconds;

        if (t >= timerIndex)
        {
            YouWin();
        }
    }

    private void YouWin()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
