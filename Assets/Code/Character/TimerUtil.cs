using System.Collections;
using System;
using UnityEngine;
/*
*   TimerUtil is a Singleton handling all Actions that needs to happen after a float of time.
*/
public class TimerUtil : MonoBehaviour, ITIMER
{
    public static TimerUtil Instance { get; private set; }

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void SetTimer(float time, Action timerAction)
    {
        StartCoroutine(Timer(time, timerAction));
    }

    private IEnumerator Timer(float time, Action timerAction)
    {
        yield return new WaitForSeconds(time);

        timerAction();
    }
}
