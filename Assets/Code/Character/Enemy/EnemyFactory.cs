using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, ICREATE
{
    private DifficultyMaster difficultyMaster;

    public void SetDiffMaster(DifficultyMaster difficultyMaster)
    {
        this.difficultyMaster = difficultyMaster;
    }

    public List<GameObject> Create()
    {
        throw new System.NotImplementedException();
    }
}
