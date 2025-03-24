using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IINSTRUCTOR
{
    public float GetMod();
    public List<GameObject> GetObjects();
    public List<GameObject> GetAvailableObjects();
    public List<GameObject> GetUnavailableObjects();
    public GameObject GetTargetObject();
}
