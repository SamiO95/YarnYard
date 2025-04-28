using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAXEL
{
    void SetRotationSpeed(float rotationSpeed);
    void SetRotationBounds(float rotationBounds);
    void SetRotationReset(float rotationReset);
    void Activate();
    void Deactivate();
}
