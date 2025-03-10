using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyCalculator
{
    private enum Difficulty { Easy, Normal, Hard };

    private Difficulty _Difficulty = Difficulty.Normal;

    private readonly float TIMEMOD = 10f;
    private readonly float EASYMOD = 0.5f;
    private readonly float NORMALMOD = 1f;
    private readonly float HARDMOD = 3f;

    public float GetTimeDifficultyMod() 
    {
        return _Difficulty switch
        {
            Difficulty.Easy => (Time.deltaTime * TIMEMOD * EASYMOD),
            Difficulty.Normal => (Time.deltaTime * TIMEMOD * NORMALMOD),
            Difficulty.Hard => (Time.deltaTime * TIMEMOD * HARDMOD)
        };
    }

    public void SetDifficulty(int _Difficulty) 
    {
        if(_Difficulty >= 0 && _Difficulty <= 2)
        { 
            this._Difficulty = _Difficulty switch 
            { 
                0 => Difficulty.Easy,
                1 => Difficulty.Normal,
                2 => Difficulty.Hard
            };
        }
    }
}
