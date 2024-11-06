using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level25ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level25Completed = true;

        if (LevelManager.Level25Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level25Score)
            {
                ScoreSystem.Score = LevelManager.Level25Score;
                if (LevelManager.Level25Score > Star3)
                {
                    LevelManager.Level25Stars = 3;
                }
                else if (LevelManager.Level25Score > Star2)
                {
                    LevelManager.Level25Stars = 2;
                }
                else
                {
                    LevelManager.Level25Stars = 1;
                }
            }
        }
    }
}
