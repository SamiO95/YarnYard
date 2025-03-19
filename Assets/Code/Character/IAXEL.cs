using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAXEL
{
    void Activate(int damage);

    void Deactivate();

    void SetTimer(float time, Action timerAction);
}
