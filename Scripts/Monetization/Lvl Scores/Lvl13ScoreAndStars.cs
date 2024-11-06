using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level13ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level13Completed = true;

        if (LevelManager.Level13Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level13Score)
            {
                ScoreSystem.Score = LevelManager.Level13Score;
                if (LevelManager.Level13Score > Star3)
                {
                    LevelManager.Level13Stars = 3;
                }
                else if (LevelManager.Level13Score > Star2)
                {
                    LevelManager.Level13Stars = 2;
                }
                else
                {
                    LevelManager.Level13Stars = 1;
                }
            }
        }
    }
}
