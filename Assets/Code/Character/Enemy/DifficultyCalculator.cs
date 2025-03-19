using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyCalculator
{
    public DifficultyCalculator(int difficulty) 
    {
        SetDifficulty(difficulty);
    }

    private enum Difficulty { Easy, Normal, Hard };

    private Difficulty difficulty = Difficulty.Normal;

    private readonly float TIMEMOD = 10f;
    private readonly float EASYMOD = 0.5f;
    private readonly float NORMALMOD = 1f;
    private readonly float HARDMOD = 3f;

    public float GetTimeDifficultyMod() 
    {
        return difficulty switch
        {
            Difficulty.Easy => (Time.deltaTime * TIMEMOD * EASYMOD),
            Difficulty.Normal => (Time.deltaTime * TIMEMOD * NORMALMOD),
            Difficulty.Hard => (Time.deltaTime * TIMEMOD * HARDMOD),
            _ => (Time.deltaTime * TIMEMOD * NORMALMOD)
        };
    }

    public void SetDifficulty(int difficulty) 
    {
        if(difficulty >= 0 && difficulty <= 2)
        { 
            this.difficulty = difficulty switch 
            { 
                0 => Difficulty.Easy,
                1 => Difficulty.Normal,
                2 => Difficulty.Hard,
                _ => Difficulty.Normal
            };
        }
    }
}
