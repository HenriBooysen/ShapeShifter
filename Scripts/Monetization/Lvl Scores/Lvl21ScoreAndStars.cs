using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level21ScoreAndStars : MonoBehaviour
{
    // Start is called before the first frame update
    public int Star2;
    public int Star3;

    void OnEnable()
    {
        LevelManager.Level21Completed = true;

        if (LevelManager.Level21Completed)
        {
            if (ScoreSystem.Score > LevelManager.Level21Score)
            {
                ScoreSystem.Score = LevelManager.Level21Score;
                if (LevelManager.Level21Score > Star3)
                {
                    LevelManager.Level21Stars = 3;
                }
                else if (LevelManager.Level21Score > Star2)
                {
                    LevelManager.Level21Stars = 2;
                }
                else
                {
                    LevelManager.Level21Stars = 1;
                }
            }
        }
    }
}
