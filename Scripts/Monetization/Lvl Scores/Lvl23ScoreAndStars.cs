using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level23ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level23Completed = true;

        if (LevelManager.Level23Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level23Score)
            {
                ScoreSystem.Score = LevelManager.Level23Score;
                if (LevelManager.Level23Score > Star3)
                {
                    LevelManager.Level23Stars = 3;
                }
                else if (LevelManager.Level23Score > Star2)
                {
                    LevelManager.Level23Stars = 2;
                }
                else
                {
                    LevelManager.Level23Stars = 1;
                }
            }
        }
    }
}
